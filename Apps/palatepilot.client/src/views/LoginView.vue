<script setup lang="ts">
import { computed, ref, watch } from "vue";
import { useRouter } from "vue-router";
import { useAuthStore } from "@/stores/authStore";
import type { LoginRequest } from "@/requests/loginRequest";
import PrimaryButton from "@/components/PrimaryButton.vue";
import BaseInputField from "@/components/BaseInputField.vue";
import FormControl from "@/components/FormControl.vue";

const router = useRouter();
const authStore = useAuthStore();
const loginRequest = ref<LoginRequest>({} as LoginRequest);

const isAuthenticated = computed(() => authStore.isAuthenticated);

watch(isAuthenticated, () => router.push("/"));

async function handleLoginButton() {
  authStore.login(loginRequest.value);
}
</script>

<template>
  <section class="hero is-fullheight">
    <div class="hero-body">
      <div class="container has-text-centered">
        <div class="columns">
          <header class="column mb-5">
            <h1 class="title">Login today</h1>
          </header>
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
          <footer class="column is-flex is-flex-direction-column is-gap">
            <RouterLink class="is-size-6" to="#">Forgot Password</RouterLink>
            <RouterLink class="is-size-6" to="/registration"
              >Create an Account</RouterLink
            >
          </footer>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
.is-gap {
  gap: 0.25rem;
}
</style>
