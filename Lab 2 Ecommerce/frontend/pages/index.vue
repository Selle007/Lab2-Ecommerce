<template>
    <div>
      <NuxtLayout name="client">
        <template #header></template>
            
            <Slider />
            
            <FeaturedProducts />
            
            <Reviews />
        <template #footer></template>
      </NuxtLayout>
    </div>
  </template>
  
  <script setup>
  definePageMeta({
    layout: false,
  });
  </script>
  