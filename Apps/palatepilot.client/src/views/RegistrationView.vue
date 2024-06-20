<script setup lang="ts">
import { ref,  watch } from 'vue'
import { useRouter }   from 'vue-router';
import userService from "@/services/userService";
import type { RegisterRequest } from '@/requests/registerRequest';
import PrimaryButton from '@/components/PrimaryButton.vue';
import BaseInputField from '@/components/BaseInputField.vue';

const response = ref("");
const registerRequest = ref<RegisterRequest>({} as RegisterRequest);
const router = useRouter();

watch(response, async (newResponse) => {
  if(newResponse == "Registration Successfull."){
    router.push('/login')
  }
});

async function handleSignUpButton(){
  response.value = await userService.registration(registerRequest.value);
}
</script>

<template>
  <!-- Section -->
  <section class="hero is-fullheight">
    <div class="hero-body ">
      <div class=" container has-text-centered">
        <div class="columns">
          <!-- Header -->
          <header class="column mb-5">
            <h1 class="title">Sign up today</h1>
          </header>
          <!-- Main content -->
          <main class="column">
              <form @submit.prevent="handleSignUpButton">
              <div class="field">
                <div class="control">
                  <BaseInputField 
                    v-model="registerRequest.username"
                    type="text"
                    placeholder="Username"
                  />
                </div>
              </div>
              <div class="field">
                <div class="control">
                  <BaseInputField 
                    v-model="registerRequest.email"
                    type="email"
                    placeholder="Email"
                  />
                </div>
              </div>
              <div class="field mb-5">
                <div class="control">
                  <BaseInputField 
                    v-model="registerRequest.password"
                    type="password"
                    placeholder="Password"
                  />                  
                </div>
              </div>
              <!-- Login button -->
              <div class="field">
                <div class="control">
                  <PrimaryButton label="Sign Up" />
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
