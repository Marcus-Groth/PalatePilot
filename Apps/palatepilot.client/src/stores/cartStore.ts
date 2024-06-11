import type { Cart } from "@/models/cart";
import cartService from "@/services/cartService";
import { defineStore } from "pinia"
import { ref, watch } from "vue"

export const useCartStore = defineStore('cart', () => {

    // states
    const cart = ref<Cart>({} as Cart);
    const storedCart = localStorage.getItem('cart')
    
    if(storedCart != null){
        cart.value = JSON.parse(storedCart);
    }

    
    // actions
    async function getCart(){
        const result = await cartService.getCart();
        localStorage.setItem('cart', JSON.stringify(result));
    }
  
})