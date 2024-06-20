<script setup lang="ts">
import { ref,  watch } from 'vue'
import { useRouter }   from 'vue-router';
import userService from "@/services/userService";
import type { RegisterRequest } from '@/requests/registerRequest';
import PrimaryButton from '@/components/PrimaryButton.vue';
import BaseInputField from '@/components/BaseInputField.vue';
import FormControl from '@/components/FormControl.vue';

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
                <FormControl>
                  <BaseInputField 
                    v-model="registerRequest.username"
                    type="text"
                    placeholder="Username"
                  />
                </FormControl>

                <FormControl>
                  <BaseInputField 
                    v-model="registerRequest.email"
                    type="email"
                    placeholder="Email"
                  />
                </FormControl>

                <FormControl>
                  <BaseInputField 
                    v-model="registerRequest.password"
                    type="password"
                    placeholder="Password"
                  />
                </FormControl>

                <div class="mb-5"></div>

                <FormControl>
                  <PrimaryButton label="Sign Up" />
                </FormControl>
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
