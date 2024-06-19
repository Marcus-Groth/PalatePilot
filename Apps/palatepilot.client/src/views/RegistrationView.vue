<script setup lang="ts">
import { ref,  watch } from 'vue'
import userService from "@/services/userService";
import { useRouter }   from 'vue-router';
import type { RegisterRequest } from '@/requests/registerRequest';

// Define ref properties
const response = ref("");
const registerRequest = ref<RegisterRequest>({} as RegisterRequest);
const router = useRouter();

async function handleSignUpButton(){
  response.value = await userService.registration(registerRequest.value);
}

watch(response, async (newResponse) => {
  if(newResponse == "Registration Successfull."){
    router.push('/login')
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
            <h1 class="title">Sign up today</h1>
          </header>
          <!-- Main content -->
          <main class="column">
              <form @submit.prevent="handleSignUpButton">
              <!-- Username field -->
              <div class="field">
                <div class="control">
                  <input v-model="registerRequest.username" class="input is-medium is-success" type="text" placeholder="Username">
                </div>
              </div>

              <!-- Email field -->
              <div class="field">
                <div class="control">
                  <input v-model="registerRequest.email" class="input is-medium is-success" type="email" placeholder="Email">
                </div>
              </div>
              
              <!-- Password field -->
              <div class="field mb-5">
                <div class="control">
                  
                  <input v-model="registerRequest.password" class="input is-medium is-success" type="password" placeholder="Password">
                </div>
              </div>
              <!-- Login button -->
              <div class="field">
                <div class="control">
                  <button class="button is-block is-fullwidth is-medium is-primary">Sign Up</button>
                </div>
              </div>
            </form>
          </main>
          <!-- Footer -->
          <footer class="column">
            <div>
              <!-- Footer links -->
              <div class="mb-2">
                <RouterLink class="is-size-6" to="/login">Already have an account?</RouterLink>
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
