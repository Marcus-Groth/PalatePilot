<script setup lang="ts">
defineProps<{
  label: string;
}>();
</script>

<template>
  <button class="button is-block is-fullwidth is-medium is-primary">
    {{ label }}
  </button>
</template>
