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

  // getters
  const cartList = computed(() => cart.value.cartItems || []);
  const subTotal = computed(() => cart.value.subTotal);

  const cartCount = computed(() =>
    cartList.value.reduce((total, item) => {
      return total + item.quantity;
    }, 0)
  );

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
      cart.value = response.data.data;
    } catch (error: any) {
      const response: ErrorResponse = error.response;
      console.error(response.errors);
    }
  }

  function toggleModal() {
    isActive.value = !isActive.value;
  }

  return { isActive, cartList, subTotal, cartCount, addItemToCart, getCart, toggleModal };
});
