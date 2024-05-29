<script setup lang="ts">
import { ref, onMounted  } from 'vue'
import type { Food } from '@/models/food';
import foodService from '@/services/foodService';

// Define ref properties
const pizzas = ref([] as Food[] | undefined)

onMounted( async () => {
  pizzas.value = await foodService.getAll()
});   
</script>

<template>
  <section class="section">
    <div class="container">
      <h1 class="title">Pizza</h1>
      <div class="box" v-for="(pizza, index) in pizzas" :key="index">
        <div class="columns is-vcentered">
          <div class="column is-narrow">
            <span class="tag is-success is-medium">{{ pizza.id }}</span>
          </div>
          <div class="column">
            <h2 class="subtitle">{{ pizza.name }}</h2>
            <p>{{ pizza.ingredients }}</p>
          </div>
          <div class="column is-narrow">
              <p class="has-text-weight-bold">{{ pizza.price + "$" }}</p>
              <button @click="handleAddButton" class=" mt-4 button is-success">Add</button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
import { ref } from 'vue';

const pizzas = ref([
  { number: 1, name: "Quattro Stagioni", ingredients: "Tomatsås, Ost, Skinka, Musslor, Paprika, Oliver, Champinjoner", price: "125kr" },
  { number: 2, name: "El Paso", ingredients: "Tomatsås, Ost, Skinka, Räkor, Tonfisk, Lök", price: "125kr" },
  { number: 3, name: "Batman", ingredients: "Tomatsås, Ost, Skinka, Räkor, Ananas, Champinjoner", price: "125kr" },
  { number: 4, name: "Calzone Kebab, Inbakad", ingredients: "Tomatsås, Ost, Kebabkött", price: "125kr" },
  { number: 5, name: "Calzone Classic, Inbakad", ingredients: "Tomatsås, Ost, Skinka, Köttfärs, Färsk vitlök", price: "125kr" }
]);
</script>
