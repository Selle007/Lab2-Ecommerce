<template>
  <div>
    <NuxtLayout name="client">
      <template #header></template>
      <section class="w-screen">
        <div class="py-8 px-4 mx-auto max-w-2xl lg:py-16">


          <div role="status" class="flex justify-center mt-5 mb-5" v-if="!order">
            <svg aria-hidden="true"
              class="inline w-8 h-8 mr-2 text-gray-200 animate-spin dark:text-gray-600 fill-gray-600 dark:fill-gray-300"
              viewBox="0 0 100 101" fill="none" xmlns="http://www.w3.org/2000/svg">
              <path
                d="M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z"
                fill="currentColor" />
              <path
                d="M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z"
                fill="currentFill" />
            </svg>
            <span class="sr-only">Loading...</span>
          </div>


          <div class=" px-4 mr-2 mx-auto flex" v-if="order">

            <div>
              <h2 class="mb-2 text-xl leading-none text-black md:text-2xl ">Order Id:</h2>
              <p class="mb-2 text-xl leading-none text-black md:text-lg mr-5" > {{ order.id }}</p>
              <dl class="mt-6">
                <dt class="mb-2 text-xl leading-none text-black md:text-2xl ">Shipping address:</dt>
                <dd class="mb-2 text-md leading-none text-black md:text-lg " v-if="order && order.shippingDetails">
                  Name: {{ order.shippingDetails.name }}<br>
                  Surname: {{ order.shippingDetails.surname }}<br>
                  Country: {{ order.shippingDetails.country }}<br>
                  City: {{ order.shippingDetails.city }}<br>
                  Address: {{ order.shippingDetails.address }}<br>
                  ZipCode: {{ order.shippingDetails.zipCode }}</dd>
              </dl>
              <dl class="mt-6">
                <p class="mb-2 text-xl leading-none text-black md:text-2xl ">Order Total:  {{ order.total }}&euro;</p>
              </dl>

              <dl class="mt-6">
                <dt class="mb-2 text-xl leading-none text-black md:text-2xl ">Status: <span
                    v-if="order.status === 'Processing'"
                    class="py-2 bg-indigo-100 text-indigo-800 text-xs font-medium mr-2 px-2.5 py-0.5 rounded-full dark:bg-indigo-900 dark:text-indigo-300">Processing</span>
                  <span v-if="order.status === 'Shipped'"
                    class="py-2 bg-yellow-100 text-yellow-800 text-xs font-medium mr-2 px-2.5 py-0.5 rounded-full dark:bg-yellow-900 dark:text-yellow-300">Shipped</span>
                  <span v-if="order.status === 'Completed'"
                    class="py-2 bg-green-100 text-green-800 text-xs font-medium mr-2 px-2.5 py-0.5 rounded-full dark:bg-green-900 dark:text-green-300">Completed</span>
                </dt>



              </dl>

              <a href="/orders"
                class="inline-flex items-center mt-5 px-5 py-2.5 text-sm font-medium text-center text-white bg-emerald-600 rounded-lg focus:ring-4 focus:ring-primary-200 hover:bg-emerald-700">
                Back
              </a>
            </div>
            <dl>
              <div>
                <dt class="mb-2  text-xl leading-none text-gray-900 ">Items:</dt>
                <dd class="mb-4 font-light text-gray-500 sm:mb-5 ">
                  <div>
                    <ul class="space-y-4">
                      <li class="flex items-center gap-4 border rounded-lg px-4 shadow-sm py-1 w-96"
                        v-for="item in order.items" :key="item.id">
                        <img src="product.image" alt="" class="h-16 w-16 rounded object-cover" />
                        <div>
                          <h3 class="font-semibold text-gray-900"> {{ getProductName(item.productId) }} </h3>
                          <dl class="mt-0.5 space-y-px text-[10px] text-gray-600">
                            <div>
                              <dt class="inline text-sm">Description:</dt>
                              <dd class="inline text-sm"> {{ getProductDesc(item.productId) }} </dd>
                            </div>
                            <div>
                              <dt class="inline text-sm">Quantity:</dt>
                              <dd class="inline text-sm">{{ item.quantity }} </dd>
                            </div>
                          </dl>
                        </div>
                      </li>
                    </ul>
                  </div>
                </dd>
              </div>

            </dl>


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
      order: null,
      products: [],
    };
  },
  async mounted() {
    try {
      let orderId = this.$route.params.id
      const response = await api.getOrderById(orderId) // wait for the Promise to resolve
      this.order = response.data
      this.loading = false;
    } catch (error) {
      console.error(error)
      this.loading = true;
    }
    try {
      const products = await api.getProducts() // wait for the Promise to resolve
      this.products = products.data
      console.log(this.products);
    } catch (error) {
      console.error(error)
    }

  },
  methods: {
    async handleUpdateForm() {
      const orderId = this.order.id;
      try {
        const response = await api.updateOrderStatus(orderId, this.order.status);
        // redirect to the updated order page
        this.$router.push(`/dashboard/order/list-orders`);
      } catch (error) {
        console.error(error);
      }
    },
    getProductImage(productId) {
      const product = this.products.find((p) => p.id === productId);
      return product ? product.image : "";
    },
    getProductName(productId) {
      const product = this.products.find((p) => p.id === productId);
      return product ? product.name : "";
    },
    getProductQuanitity(productId) {
      const product = this.products.find((p) => p.id === productId);
      return product ? product.quantity : "";
    },
    getProductDesc(productId) {
      const product = this.products.find((p) => p.id === productId);
      return product ? product.description : "";
    },
  },
}
</script>
