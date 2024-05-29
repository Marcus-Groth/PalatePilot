import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '../views/LoginView.vue'
import localService from '@/services/localService';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/login',
      name: 'login',
      component: LoginView
    },
    {
      path: '/registration',
      name: 'registration',
      component: () => import('../views/RegistrationView.vue')
    },
    {
      path: '/',
      name: 'home',
      component: () => import('../views/HomeView.vue'),
      meta: {
        requiresAuth: true
      }
    }
  ]
});

router.beforeEach((to, from, next) => {
  const jwtToken = localService.get("jwt")

  if (to.meta.requiresAuth && !jwtToken) {
    next('/login');
  } 
  
  else if (!to.meta.requiresAuth && jwtToken) {
    next(from);
  } 
  
  else {
    next();
  }
});

export default router
