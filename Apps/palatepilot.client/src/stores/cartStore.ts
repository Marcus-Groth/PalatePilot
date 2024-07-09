import { defineStore } from "pinia";
import { computed, ref, watch } from "vue";
import type { Cart } from "@/models/cart";
import authAxios from "@/interceptors/authAxios";
import type { ErrorResponse } from "@/models/errorResponse";
import type { SuccessResponse } from "@/models/successResponse";

export const useCartStore = defineStore("cart", () => {
  // states
  const cart = ref<Cart>({} as Cart);
  const isActive = ref(false);
  const storedCart = localStorage.getItem("cart");

  if (storedCart != null) {
    cart.value = JSON.parse(storedCart);
  }

  // getters
  const cartList = computed(() => cart.value.cartItems);
  const subTotal = computed(() => cart.value.subTotal);

  // actions
  async function addItemToCart(foodId: number) {
    try {
      const response = await authAxios.post<SuccessResponse>(
        `/Cart?FoodId=${foodId}`
      );
      console.log(response.data);
    } catch (error: any) {
      const response: ErrorResponse = error.response;
      console.error(response.errors);
    }
  }

  async function getCart() {
    try {
      const response = await authAxios.get<SuccessResponse>(`/Cart`);
      console.log(response.data);
      localStorage.setItem("cart", JSON.stringify(response));
    } catch (error: any) {
      const response: ErrorResponse = error.response;
      console.error(response.errors);
    }
  }

  function toggleModal() {
    isActive.value = !isActive.value;
  }

  return { isActive, cartList, subTotal, addItemToCart, getCart, toggleModal };
});
