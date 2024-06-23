import { defineStore } from 'pinia';
import { ref } from 'vue';
import type { Food } from '@/models/food';
import authAxios from '@/interceptors/authAxios';
import type { SuccessResponse } from '@/models/successResponse';
import type { ErrorResponse } from '@/models/errorResponse';

export const useFoodStore = defineStore('food', () => {
    // state
    const foodList = ref<Food[]>([]);

    // actions
    async function getAll(){
        try {
          const response = await authAxios<SuccessResponse>("/Food");
          console.log(response.data.data);
          foodList.value = response.data.data
        }

        catch (error: any) {
          const response: ErrorResponse = error.response
          console.error(response.errors);
        }
    }

    return {foodList, getAll};
});