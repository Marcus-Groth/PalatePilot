import type { Cart } from "@/models/cart";
import cartService from "@/services/cartService";
import { defineStore } from "pinia"
import { computed, ref, watch } from "vue"

export const useCartStore = defineStore('cart', () => {

    // states
    const cart = ref<Cart>({} as Cart);
    const storedCart = localStorage.getItem('cart')
    
    if(storedCart != null){
        cart.value = JSON.parse(storedCart);
    }

    // getters
    const cartList = computed(() => cart.value.cartItems)

    // actions
    async function getCart(){
        const result = await cartService.getCart();
        localStorage.setItem('cart', JSON.stringify(result));
    }

    return { cartList, getCart }
})