<script setup lang="ts">
const model = defineModel();

defineProps<{
  type: string;
  placeholder: string;
}>();
</script>

<template>
  <input
    v-model="model"
    class="input is-medium is-primary"
    :type="type"
    :placeholder="placeholder"
  />
</template>
