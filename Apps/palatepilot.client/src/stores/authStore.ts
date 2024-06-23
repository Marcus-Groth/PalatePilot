import { defineStore } from 'pinia';
import { computed, ref } from 'vue';
import baseAxios from '@/interceptors/baseAxios';
import localService from '@/services/localService';
import type { LoginRequest } from '@/requests/loginRequest';
import type { SuccessResponse } from '@/models/successResponse';
import type { ErrorResponse } from '@/models/errorResponse';

export const useAuthStore = defineStore('auth', () => {
    // states
    const jwtToken = ref<string | null>(localService.get('jwt'));
    
    // getters
    const isAuthenticated = computed(() => !!jwtToken.value);

    // actions
    async function login(loginRequest: LoginRequest) {
      try {
        const response = await baseAxios.post<SuccessResponse>('/Auth/Login', loginRequest);
        console.log(response.data);
        localService.set("jwt", response.data.data);
        jwtToken.value = response.data.data;
      } 
      catch (error: any) {
        const response: ErrorResponse = error.data;
        console.error(response.errors);
      }
    }

    function logout() {
      localService.delete("jwt");
      console.log("Logout was Successfull");
      jwtToken.value = null;
    }
    
    return { jwtToken, isAuthenticated, login, logout }
})
