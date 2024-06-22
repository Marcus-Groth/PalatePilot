import baseAxios from '@/interceptors/baseAxios';
import type { RegisterRequest } from '@/requests/registerRequest';
import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useUserStore = defineStore('user', () => {
    // state
    const successMessage = ref('');
    const errorMessage = ref('');

    // actions
    async function registration(registerRequest: RegisterRequest) {
        try {
          const response = await baseAxios.post('/User/Registration', registerRequest);
          console.log(response.data);
          successMessage.value = response.data.message;
        } 
    
        catch (error: any) {
          const response = error.response;
          console.error(response.data);
          errorMessage.value = response.data.errors
        }
    }
    
    return { successMessage, errorMessage, registration }
})
