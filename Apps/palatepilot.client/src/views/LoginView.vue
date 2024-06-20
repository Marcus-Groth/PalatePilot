<script setup lang="ts">
import { computed, ref, watch } from 'vue'
import type { LoginRequest } from '@/requests/loginRequest';
import { useRouter }   from 'vue-router';
// import { useCartStore } from '@/stores/cartStore';
import { useAuthStore } from '@/stores/authStore';

import PrimaryButton from '@/components/PrimaryButton.vue';



const router = useRouter();
const authStore = useAuthStore();
// const cartStore = useCartStore()

const loginRequest = ref<LoginRequest>({} as LoginRequest);

const isAuthenticated = computed(() => authStore.isAuthenticated);
watch( isAuthenticated, () => router.push('/'));

async function handleLoginButton(){
  authStore.login(loginRequest.value);
  // cartStore.getCart()
}

</script>

<template>
  
  <!-- Section -->
  <section class="hero is-fullheight">
    <div class="hero-body">
      <div class="container has-text-centered">
        <div class="columns">
          <!-- Header -->
          <header class="column mb-5">
            <h1 class="title">Login today</h1>
          </header>
          <!-- Main content -->
          <main class="column">
            <form @submit.prevent="handleLoginButton">
              <!-- Username field -->
              <div class="field">
                <div class="control">
                  <input v-model="loginRequest.username" class="input is-medium is-primary" type="text" placeholder="Username">
                </div>
              </div>
              <div class="field mb-5">
                <div class="control">
                  <!-- Password field -->
                  <input v-model="loginRequest.password" class="input is-medium is-primary" type="password" placeholder="Password">
                </div>
              </div>
              <!-- Login button -->
              <div class="field">
                <div class="control">
                  <PrimaryButton label="Login" />
                </div>
              </div>
            </form>
          </main>
          <!-- Footer -->
          <footer class="column">
            <div>
              <!-- Footer links -->
              <div class="mb-2">
                <a class="is-size-6" href="#">Forgot Password?</a>
              </div>
              <div>
                <RouterLink class="is-size-6" to="/registration">Create an Account</RouterLink>
              </div>
            </div>
          </footer>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
</style>