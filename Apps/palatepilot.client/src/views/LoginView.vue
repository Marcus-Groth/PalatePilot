<script setup lang="ts">
import { computed, ref, watch } from 'vue'
import { useRouter }   from 'vue-router';
import { useAuthStore } from '@/stores/authStore';
import type { LoginRequest } from '@/requests/loginRequest';
import PrimaryButton from '@/components/PrimaryButton.vue';
import BaseInputField from '@/components/BaseInputField.vue';
import FormControl from '@/components/FormControl.vue';

const router = useRouter();
const authStore = useAuthStore();
const loginRequest = ref<LoginRequest>({} as LoginRequest);

const isAuthenticated = computed(() => authStore.isAuthenticated);

watch( isAuthenticated, () => router.push('/'));

async function handleLoginButton(){
  authStore.login(loginRequest.value);
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
              <FormControl>
                <BaseInputField 
                  v-model="loginRequest.username"
                  type="text"
                  placeholder="Username"
                />
              </FormControl>
              
             <FormControl>
                <BaseInputField 
                  v-model="loginRequest.password"
                  type="password"
                  placeholder="Password"
                />
              </FormControl>

              <div class="mb-5"></div>

              <FormControl>
                <PrimaryButton label="Login" />
              </FormControl>
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