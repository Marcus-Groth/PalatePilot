import localService from "@/services/localService"
import { defineStore } from "pinia"
import { ref, watch } from "vue"

export const useCartStore = defineStore('counter', () => {
    const cartCount = ref(
        Number(localService.get('cart_counter'))
    )

    watch(cartCount, () => {
        localService.set('cart_counter', cartCount.value.toString())
    });
      
    function increment() {
      cartCount.value++
    }
    
    function decrement(){
        cartCount.value--;
    }
  
    return { cartCount, increment, decrement }
  })