<template>
  <div>
    <NuxtLayout name="admin">
      <template #header></template>
      <section class="bg-white w-screen">
        <div class="py-8 px-4 mx-auto max-w-2xl lg:py-16">
          <h2 class="mb-4 text-xl font-bold text-gray-900">Edit Product</h2>
          <form @submit.prevent="handleUpdateForm">
            <div class="grid gap-4 sm:grid-cols-2 sm:gap-6">
              <div class="sm:col-span-2">
                <label for="productName"
                  class="relative block overflow-hidden rounded-md border border-gray-200 px-3 pt-3 shadow-sm focus-within:border-blue-600 focus-within:ring-1 focus-within:ring-blue-600">
                  <input type="text" id="productName" placeholder="Product Name"
                    class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"
                    v-model="product.name" required />

                  <span
                    class="absolute left-3 top-3 -translate-y-1/2 text-xs text-gray-700 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Product Name
                  </span>
                </label>
              </div>

              <div class="sm:col-span-2">
                <label for="productDescription"
                  class="relative block overflow-hidden rounded-md border border-gray-200 px-3 pt-3 shadow-sm focus-within:border-blue-600 focus-within:ring-1 focus-within:ring-blue-600">
                  <input type="text" id="productDescription" placeholder="Product Description"
                    class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"
                    v-model="product.description" required />

                  <span
                    class="absolute left-3 top-3 -translate-y-1/2 text-xs text-gray-700 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Product Description
                  </span>
                </label>
              </div>

              <div class="sm:col-span-2">
                <label for="productPrice"
                  class="relative block overflow-hidden rounded-md border border-gray-200 px-3 pt-3 shadow-sm focus-within:border-blue-600 focus-within:ring-1 focus-within:ring-blue-600">
                  <input type="text" id="productPrice" placeholder="Product Price"
                    class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"
                    v-model="product.price" required />

                  <span
                    class="absolute left-3 top-3 -translate-y-1/2 text-xs text-gray-700 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Product Price
                  </span>
                </label>
              </div>

              <div class="sm:col-span-2">
                <label for="productStock"
                  class="relative block overflow-hidden rounded-md border border-gray-200 px-3 pt-3 shadow-sm focus-within:border-blue-600 focus-within:ring-1 focus-within:ring-blue-600">
                  <input type="number" id="productStock" placeholder="Product Stock"
                    class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"
                    v-model="product.stock" required />

                  <span
                    class="absolute left-3 top-3 -translate-y-1/2 text-xs text-gray-700 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Product Stock
                  </span>
                </label>
              </div>

              <div class="sm:col-span-2">
                <label for="productImage"
                  class="relative block overflow-hidden rounded-md border border-gray-200 px-3 pt-3 shadow-sm focus-within:border-blue-600 focus-within:ring-1 focus-within:ring-blue-600">
                  <input type="text" id="productImage" placeholder="Product Image"
                    class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"
                    v-model="product.image" required />

                  <span
                    class="absolute left-3 top-3 -translate-y-1/2 text-xs text-gray-700 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Product Image
                  </span>
                </label>
              </div>

              <div class="sm:col-span-2">
                <label for="MarketingAccept" class="flex gap-4">
                  <span class="text-sm text-gray-700"> Featured </span>
                  <input type="checkbox" id="MarketingAccept" name="marketing_accept"
                    class="h-5 w-5 rounded-md border-gray-200 bg-white shadow-sm " v-model="product.isFeatured" />
                </label>
              </div>

 
              <div class="sm:col-span-2">
                <label for="productCategory"
                  class="relative block overflow-hidden rounded-md border border-gray-200 px-3 pt-3 shadow-sm focus-within:border-blue-600 focus-within:ring-1 focus-within:ring-blue-600">
                  <select type="text" id="productCategory" placeholder="Product Category"
                    class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"
                    v-model="product.categoryId" required>
                    <option
                      class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"
                      v-for="category in Categories" :key="category.id" :value="category.id">
                      {{ category.name }}
                    </option>
                  </select>

                  <span
                    class="absolute left-3 top-3 -translate-y-1/2 text-xs text-gray-700 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Product Category
                  </span>
                </label>
              </div>
            </div>
            <button
              class="inline-flex items-center px-5 py-2.5 mt-4 sm:mt-6 text-sm font-medium text-center text-white bg-emerald-600 rounded-lg focus:ring-4 focus:ring-primary-200 hover:bg-emerald-700">
              Edit
            </button>
          </form>
        </div>
      </section>
    </NuxtLayout>
  </div>
</template>

<script>
import api from '@/services/api'
export default {
  head() {
    return {
      layout: false,

    }
  },
  data() {
    return {
      product: {},
      Categories: [],
    };
  },
  async mounted() {
    try {
      const response = await api.getCategories() // wait for the Promise to resolve
      this.Categories = response.data
      console.log(this.Categories);
    } catch (error) {
      console.error(error)
    }
    try {
      let productId = this.$route.params.id
      const response = await api.getProductsById(productId) // wait for the Promise to resolve
      this.product = response.data
      
        console.log(this.product);
      this.loading = false;
    } catch (error) {
      console.error(error)
      this.loading = true;
    }
  },
  methods: {
    async handleUpdateForm() {
      const productId = this.product.id;
      try {
        const response = await api.updateProduct(productId, this.product);
        console.log(response);
        // redirect to the updated product page
        this.$router.push(`/dashboard/product/list-products`);
      } catch (error) {
        console.error(error);
      }
    },
  },
}
</script>
