import type { Cart } from "@/models/cart";
import cartService from "@/services/cartService";
import { defineStore } from "pinia"
import { computed, ref, watch } from "vue"

export const useCartStore = defineStore('cart', () => {

    // states
    const cart = ref<Cart>({} as Cart);
    const isActive = ref(false);
    const storedCart = localStorage.getItem('cart')
    
    if(storedCart != null){
        cart.value = JSON.parse(storedCart);
    }

    // getters
    const cartList = computed(() => cart.value.cartItems)
    const subTotal = computed(() => cart.value.subTotal);

    // actions
    async function getCart(){
        const result = await cartService.getCart();
        localStorage.setItem('cart', JSON.stringify(result));
    }

    function toggleModal(){
        isActive.value = !isActive.value;
    }

    return { isActive, cartList, subTotal, getCart, toggleModal }
})