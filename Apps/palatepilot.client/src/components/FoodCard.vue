<script setup lang="ts">
import cartService from '@/services/cartService';
import { useFoodStore } from '@/stores/foodStore';
import { computed, onMounted } from 'vue';

const foodStore = useFoodStore();

onMounted( async () => {
  foodStore.getAll()
});

const foodList = computed(() => foodStore.foodList)

async function handleAddButton(foodId:number){
  console.log("Food Id: " + foodId)
  await cartService.addItemToCart(foodId)
}  
</script>

<template>  
    <div class="box" v-for="(food, index) in foodList" :key="index">
      <div class="columns is-vcentered">
          <div class="column is-narrow">
            <span class="tag is-success is-medium">{{ food.id }}</span>
          </div>
          <div class="column">
            <h2 class="subtitle">{{ food.name }}</h2>
            <p>{{ food.ingredients }}</p>
          </div>
          <div class="column is-narrow">
              <p class="has-text-weight-bold">{{ food.price + "$" }}</p>
              <button @click="handleAddButton(food.id)" class=" mt-4 button is-success">Add</button>
          </div>
      </div>
    </div>
</template>