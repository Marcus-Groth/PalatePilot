<script setup lang="ts">
import { computed, ref,  watch } from 'vue'
import { useRouter }   from 'vue-router';
import { useUserStore } from '@/stores/userStore';
import type { RegisterRequest } from '@/requests/registerRequest';
import PrimaryButton from '@/components/PrimaryButton.vue';
import BaseInputField from '@/components/BaseInputField.vue';
import FormControl from '@/components/FormControl.vue';

const router = useRouter();
const userStore = useUserStore();
const registerRequest = ref<RegisterRequest>({} as RegisterRequest);

const successMessage = computed(() => userStore.successMessage);

watch(successMessage, () => router.push('/login'));

async function handleSignUpButton(){
  await userStore.registration(registerRequest.value);
}
</script>

<template>
  <section class="hero is-fullheight">
    <div class="hero-body ">
      <div class=" container has-text-centered">
        <div class="columns">
          <header class="column mb-5">
            <h1 class="title">Sign up today</h1>
          </header>
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
          <footer class="column">
            <RouterLink class="is-size-6" to="/login">Already have an account?</RouterLink>
          </footer>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
</style>
