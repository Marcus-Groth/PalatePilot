<script setup lang="ts">
import { ref, onMounted  } from 'vue'
import type { Food } from '@/models/food';
import foodService from '@/services/foodService';
import cartService from '@/services/cartService';

// Define ref properties
const pizzas = ref([] as Food[] | undefined)

async function handleAddButton(foodId:number){
  console.log("Food Id: " + foodId)
  await cartService.addItemToCart(foodId)
}
  
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
              <button @click="handleAddButton(pizza.id)" class=" mt-4 button is-success">Add</button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>