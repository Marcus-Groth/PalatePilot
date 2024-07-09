<script setup lang="ts">
import { useCartStore } from "@/stores/cartStore";
import PrimaryButton from "./PrimaryButton.vue";

const cartStore = useCartStore();

function handleCheckoutButton() {}

function handleExitButton() {
  cartStore.toggleModal();
  document.body.classList.remove("no-scroll");
}
</script>

<template>
  <div :class="{ 'is-active': cartStore.isActive }" class="modal">
    <div class="modal-card hero is-fullheight">
      <header class="modal-card-head">
        <h1 class="modal-card-title has-text-centered has-text-weight-semibold">
          Shopping Cart
        </h1>
        <button
          @click="handleExitButton"
          class="delete"
          aria-label="close"
        ></button>
      </header>
      <section class="modal-card-body">
        <ul class="is-flex is-flex-direction-column is-gap">
          <li
            class="is-size-6"
            v-for="(cartItem, index) in cartStore.cartList"
            :key="index"
          >
            <strong>{{ cartItem.quantity + " x " + cartItem.name }}</strong>
            <span
              class="has-text-weight-bold has-text-danger is-pulled-right"
              >{{ cartItem.price }}</span
            >
          </li>
        </ul>
      </section>
      <footer class="modal-card-foot">
        <div class="container">
          <p class="mb-2 is-size-6">
            <strong>Total Sum</strong>
            <span class="is-pulled-right"> {{ cartStore.subTotal }} $</span>
          </p>
          <PrimaryButton label="Checkout" />
        </div>
      </footer>
    </div>
  </div>
</template>

<style scoped>
.is-gap {
  gap: 1.5rem;
}
</style>
