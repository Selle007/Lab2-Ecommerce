<template>
  <div>
    <NuxtLayout name="client">
      <template #header></template>
      <main class="flex-grow py-16">
        <div class="max-w-lg mx-auto bg-white rounded-lg shadow-md p-8 px-16">
          <h1 class="text-3xl font-semibold text-gray-800 mb-4">Order Complete</h1>
          <p class="text-gray-600 mb-6">Thank you for your order! We have received your payment and will process your order shortly.</p>
          <div class="flex justify-center">
            <a href="/"><button class="bg-emerald-500 hover:bg-emerald-600 text-white font-semibold py-2 px-4 rounded">
              Continue Shopping
            </button></a>
          </div>
        </div>
      </main>
      <template #footer></template>
    </NuxtLayout>
  </div>
</template>

<script>
export default {
  head() {
    return {
      layout: false,
      }
    },
  }
</script>