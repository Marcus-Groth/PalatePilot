<script setup lang="ts">
import NavBar from './components/NavBar.vue';

</script>
<template>
  <div class="mt-6">
    <NavBar />
    <RouterView />
  </div>
</template>

<style>

#app {
  margin: 0;
  padding: 0;
}

</style>
