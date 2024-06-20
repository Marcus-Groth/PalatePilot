import { defineStore } from 'pinia';
import { ref } from 'vue';
import type { Food } from '@/models/food';
import authAxios from '@/interceptors/authAxios';

export const useFoodStore = defineStore('food', () => {
    // state
    const foodList = ref<Food[]>([]);

    // actions
    async function getAll(){
        try {
          const response = await authAxios("/Food");
          console.log(response.data.data);
          foodList.value = response.data.data
        }

        catch (error: any) {
          console.error(error.response.data);
        }
    }

    return {foodList, getAll};
});