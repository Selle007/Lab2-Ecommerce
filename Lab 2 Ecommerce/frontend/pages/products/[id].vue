<template>
  <div>
    <NuxtLayout name="client">
      <template #header></template>
      <section>
        <div class="relative mx-auto max-w-screen-xl px-4 py-8">
          <div class="grid gap-8 lg:grid-cols-4 lg:items-start">
            <div class="lg:col-span-3">
              <div class="relative mt-4 flex justify-center">
                <img :src=product.image alt="Product Image" class="w-1/2 rounded-xl object-cover shadow-lg" />
              </div>
            </div>
            <div class="lg:sticky lg:top-0">
              <div class="space-y-4 lg:pt-8">
                <div>
                  <h1 class="text-2xl font-bold lg:text-3xl">{{ product.name }}</h1>
                </div>
                <div>
                  <p class="mt-1 text-sm text-gray-500">SKU: {{ product.id }}</p>
                </div>
                <div>
                  <legend class="text-lg font-bold">Description</legend>
                  <p class="mt-1 text-sm text-gray-500"> {{ product.description }} </p>
                </div>
                <div>
                  <legend class="text-lg font-bold">Stock</legend>
                  <p class="mt-1 text-sm text-gray-500"> {{ product.stock }}</p>
                </div>
                <div>
                  <p class="text-xl font-bold">{{ product.price }}&euro;</p>
                </div>
                <button :disabled="product.stock < 1"
                  class="block w-full rounded bg-emerald-600 p-4 text-sm font-medium transition hover:scale-105 text-white"
                  @click.prevent="addItemToCart(product.id, product.price)">
                  {{ product.stock < 1 ? "Out of Stock" : "Add to Cart" }} </button>
              </div>
            </div>
          </div>
        </div>
      </section>
      <div class="rounded-lg bg-white p-8 w-1/2 mx-auto lg:p-12">
        <h1 class="text-2xl font-bold lg:text-3xl pb-2">Write a review</h1>
        <form class="space-y-4" @submit.prevent="submitReview">
          <div>
            <label class="sr-only" for="name">Header</label>
            <input class="w-full rounded-lg border shadow-md p-3 text-sm" placeholder="Name" type="text" id="name"
              required v-model="submitedReview.header" />
          </div>
          <div class="grid grid-cols-1 gap-4">
            <div>
              <select id="rating" v-model="submitedReview.rating" class="w-full rounded-lg border shadow-md p-3 text-sm"
                value="5">
                <option value="5" selected>5 Stars</option>
                <option value="4">4 Stars</option>
                <option value="3">3 Stars</option>
                <option value="2">2 Stars</option>
                <option value="1">1 Star</option>
              </select>
            </div>
          </div>
          <div>
            <label class="sr-only" for="message">Message</label>
            <textarea class="w-full rounded-lg border shadow-md p-3 text-sm" placeholder="Message" rows="3" id="message"
              required v-model="submitedReview.comment"></textarea>
          </div>
          <div class="mt-4">
            <button type="submit"
              class="inline-block w-full rounded-lg bg-emerald-600 px-5 py-3 font-medium text-white sm:w-auto hover:bg-emerald-700">
              Send Enquiry
            </button>
          </div>
        </form>
      </div>
      <section>
        <h2 class="mx-auto max-w-screen-xl  text-xl font-bold sm:text-2xl">Customer Reviews</h2>
        <div class="mx-auto max-w-screen-xl px-4 py-8 sm:px-6 lg:px-8 flex">
          <div class="flex flex-row" v-for="review in Reviews" :key="review.id">
            <ProductReviews :review="review" />
          </div>
        </div>
      </section>
      <template #footer></template>
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
      submitedReview: {
        id: 'string',
        productId: '',
        header: '',
        rating: 0,
        comment: '',
        createdAt: '',
      },
      Reviews: []
    };
  },
  async mounted() {
    try {
      const response = await api.getCategories() // wait for the Promise to resolve
      this.Categories = response.data
    } catch (error) {
      console.error(error)
    }
    try {
      let productId = this.$route.params.id
      const response = await api.getProductsById(productId) // wait for the Promise to resolve
      this.product = response.data
      this.loading = false;
    } catch (error) {
      console.error(error)
      this.loading = true;
    }
    try {
      let productId = this.$route.params.id
      const response = await api.getProductReviews(productId) // wait for the Promise to resolve
      this.Reviews = response.data
      this.loading = false;
    } catch (error) {
      console.error(error)
      this.loading = true;
    }
  },
  methods: {
    async submitReview() {
      try {
        const formData = new FormData();
        let productId = this.$route.params.id
        formData.append('id', 'string');
        formData.append('productId', productId);
        formData.append('header', this.submitedReview.header);
        formData.append('rating', this.submitedReview.rating);
        formData.append('comment', this.submitedReview.comment);
        await api.createReview(formData);
        this.submitedReview = null;
        window.location.reload()
      } catch (error) {
        console.error(error);
      }
    },
  },
}
</script>