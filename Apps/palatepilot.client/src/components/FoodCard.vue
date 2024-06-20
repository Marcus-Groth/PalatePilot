<script setup lang="ts">
import { computed, onMounted } from 'vue';
import { useFoodStore } from '@/stores/foodStore';
import cartService from '@/services/cartService';

const foodStore = useFoodStore();

const foodList = computed(() => foodStore.foodList)

onMounted( async () => {
  foodStore.getAll()
});

async function handleAddButton(foodId:number){
  console.log("Food Id: " + foodId)
  await cartService.addItemToCart(foodId)
}  
</script>

<template>  
    <div class="box" v-for="(food, index) in foodList" :key="index">
      <div class="columns is-vcentered">
          <div class="column is-narrow">
            <span class="tag is-primary is-medium">{{ food.id }}</span>
          </div>
          <div class="column">
            <h2 class="subtitle">{{ food.name }}</h2>
            <p>{{ food.ingredients }}</p>
          </div>
          <div class="column is-narrow">
              <p class="has-text-weight-bold">{{ food.price + "$" }}</p>
              <button @click="handleAddButton(food.id)" class=" mt-4 button is-primary">Add</button>
          </div>
      </div>
    </div>
</template>