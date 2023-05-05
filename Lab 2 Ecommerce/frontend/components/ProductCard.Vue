<template>
  <a :href="`/products/${product.id}`" class="group relative block overflow-hidden">
    <button
      class="absolute right-4 top-4 z-10 rounded-full bg-white p-1.5 text-gray-900 transition hover:text-gray-900/75">
      <span class="sr-only">Wishlist</span>

      <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
        class="h-4 w-4">
        <path stroke-linecap="round" stroke-linejoin="round"
          d="M21 8.25c0-2.485-2.099-4.5-4.688-4.5-1.935 0-3.597 1.126-4.312 2.733-.715-1.607-2.377-2.733-4.313-2.733C5.1 3.75 3 5.765 3 8.25c0 7.22 9 12 9 12s9-4.78 9-12z" />
      </svg>
    </button>

    <img src="../assets/images/1.png" alt="Product image"
      class="h-64 w-full object-cover transition duration-500 group-hover:scale-105 sm:h-72" />

    <div class="relative border border-gray-100 bg-white p-6 flex flex-col">
      <h3 class="mt-4 text-lg font-medium text-gray-900">{{ product.name }}</h3>
      <div class="card-content flex-1">
        <h3 class="mt-4 text-lg font-medium text-gray-900">{{ product.price }}&euro;</h3>

        <form class="mt-4">
          <button :disabled="product.stock < 1"
            class="block w-full rounded bg-emerald-600 p-4 text-sm font-medium transition hover:scale-105 text-white"
            @click.prevent="addItemToCart(product.id, product.price)">
            {{ product.stock < 1 ? "Out of Stock" : "Add to Cart" }} </button>
        </form>
      </div>
    </div>
  </a>
</template>


<script>
import api from '@/services/api'
export default {
  props: {
    product: {
      type: Object,
      required: true
    }
  },
  methods: {
    async addItemToCart(productId, price) {
      try {
        const cartItem = { ProductId: productId, Quantity: 1, Price: price };
        const response = await api.addToCart(cartItem);
        console.log(response); // log the response for debugging
      } catch (error) {
        console.log(error); // log the error for debugging
      }
    },
  },
}
</script>

<style></style>