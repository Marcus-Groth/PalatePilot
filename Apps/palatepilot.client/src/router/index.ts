import { createRouter, createWebHistory } from "vue-router";
import LoginView from "../views/LoginView.vue";
import { useAuthStore } from "@/stores/authStore";
import { computed } from "vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/login",
      name: "login",
      component: LoginView,
    },
    {
      path: "/registration",
      name: "registration",
      component: () => import("../views/RegistrationView.vue"),
    },
    {
      path: "/",
      name: "home",
      component: () => import("../views/HomeView.vue"),
      meta: {
        requiresAuth: true,
      },
    },
  ],
});

router.beforeEach((to, from, next) => {
  const authStore = useAuthStore();
  const isAuthenticated = computed(() => authStore.isAuthenticated);

  if (to.meta.requiresAuth && !isAuthenticated.value) {
    next("/login");
  } else if (!to.meta.requiresAuth && isAuthenticated.value) {
    next(from);
  } else {
    next();
  }
});

export default router;
