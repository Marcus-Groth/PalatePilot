<script setup lang="ts">
import { ref, watch } from 'vue'
import type { LoginRequest } from '@/requests/loginRequest';
import authService from '@/services/authService';
import { useRouter }   from 'vue-router';
import { useCartStore } from '@/stores/cartStore';

const cartStore = useCartStore()

// Define ref properties
const loginRequest = ref<LoginRequest>({} as LoginRequest);
const response = ref("");
const router = useRouter();

async function handleLoginButton(){
  response.value = await authService.login(loginRequest.value);
  cartStore.getCart()
}

watch(response, async (newResponse) => {
  if(newResponse == "Login Successfull."){
    router.push('/')
  }
});


</script>

<template>
  <!-- Section -->
  <section class="hero is-fullheight">
    <div class="hero-body has-text-centered">
      <div class="container">
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
                  <input v-model="loginRequest.username" class="input is-medium is-success" type="text" placeholder="Username">
                </div>
              </div>
              <div class="field mb-5">
                <div class="control">
                  <!-- Password field -->
                  <input v-model="loginRequest.password" class="input is-medium is-success" type="password" placeholder="Password">
                </div>
              </div>
              <!-- Login button -->
              <div class="field">
                <div class="control">
                  <button class="button is-block is-fullwidth is-medium is-success">Login</button>
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
