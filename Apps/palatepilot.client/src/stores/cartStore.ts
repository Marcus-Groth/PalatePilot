import { defineStore } from "pinia"
import { ref, watch } from "vue"

export const useCartStore = defineStore('cart', () => {
    
    // actions
    async function getCart(){
        const result = await cartService.getCart();
        localStorage.setItem('cart', JSON.stringify(result));
    }
  
})