<template>
  <div>
    <NuxtLayout name="client">
      <template #header></template>
      <template #footer></template>
    </NuxtLayout>
  </div>
</template>

<script setup>
  definePageMeta({
    layout: false,
  });
</script>