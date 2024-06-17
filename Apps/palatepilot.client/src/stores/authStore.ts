import baseAxios from '@/interceptors/baseAxios';
import localService from '@/services/localService';
import { defineStore } from 'pinia';
import type { LoginRequest } from '@/requests/loginRequest';
import { computed, ref } from 'vue';

export const useAuthStore = defineStore('auth', () => {

    // states
    const jwtToken = ref<string | null>(localService.get('jwt'));
    
    // getters
    const isAuthenticated = computed(() => !!jwtToken.value);

    // actions
    async function login(loginRequest: LoginRequest) {
      try {
        const response = await baseAxios.post('/Auth/Login', loginRequest);
        console.log(response.data);
        localService.set("jwt", response.data.data);
        jwtToken.value = response.data.data;
      } 
      catch (error: any) {
        const response = error.response;
        console.error(response.data);
      }
    }

    function logout() {
      localService.delete("jwt");
      console.log("Logout was Successfull");
      jwtToken.value = null;
    }
    return { jwtToken, isAuthenticated, login, logout }
})
