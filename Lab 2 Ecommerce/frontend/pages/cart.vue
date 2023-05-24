<template>
  <div>
    <NuxtLayout name="client">
      <template #header></template>

      <section class="bg-gray-50 p-3 sm:p-5 w-screen">
        <div class="mx-auto max-w-screen-xl px-4 py-8 sm:px-6 sm:py-12 lg:px-8">
          <div class="mx-auto max-w-3xl">
            <header class="text-center">
              <h1 class="text-xl font-bold text-gray-900 sm:text-3xl">Your Cart</h1>
            </header>
            <!-- Cart items -->
            <div>
              <ul class="space-y-4">
              
                <li v-for="item in cartItems"
              :key="item.id">
                  <a :href="`/products/${item.productId}`"
                    class="flex items-center gap-4 border rounded-lg px-4 shadow-sm">
                    <img src="../assets/images/1.png" alt=""
                      class="h-20 w-20 rounded object-cover" />
                    <div>
                      <h3 class="text-gray-900">{{ getProductName(item.productId) }}</h3>
                      <dl class="mt-0.5 space-y-px text-[10px] text-gray-600">
                        <div>
                          <dt class="inline text-sm">Description:</dt>
                          <dd class="inline text-sm">{{ getProductDesc(item.productId) }}</dd>
                        </div>
                        <div>
                          <dt class="inline text-sm">Price:</dt>
                          <dd class="inline text-sm">{{item.price}}&euro;</dd>
                        </div>
                      </dl>
                    </div>
                    <div class="flex flex-1 items-center justify-end gap-2">
                      <form>
                        <label for="Line1Qty" class="sr-only"> {{ item.quantity }} </label>
                        <input type="number" min="1" :value="item.quantity" id="Line1Qty"
                          class="h-8 w-12 rounded border-gray-200 bg-gray-50 p-0 text-center text-xs text-gray-600 [-moz-appearance:_textfield] focus:outline-none [&::-webkit-outer-spin-button]:m-0 [&::-webkit-outer-spin-button]:appearance-none [&::-webkit-inner-spin-button]:m-0 [&::-webkit-inner-spin-button]:appearance-none">
                      </form>
                      <button class="text-gray-600 transition hover:text-red-600" @click.prevent="removeItemFromCart(item.productId)">
                        <span class="sr-only">Remove item</span>
                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                          stroke="currentColor" class="h-4 w-4">
                          <path stroke-linecap="round" stroke-linejoin="round"
                            d="M14.74 9l-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 01-2.244 2.077H8.084a2.25 2.25 0 01-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 00-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 013.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 00-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 00-7.5 0" />
                        </svg>
                      </button>
                    </div>
                  </a>
                </li>
                
                
              </ul>
              <div class="mt-8 flex justify-end border-t border-gray-100 pt-8">
                <div class="w-screen max-w-lg space-y-4">
                  <dl class="space-y-0.5 text-sm text-gray-700">
                    <div class="flex justify-end !text-base font-medium">
                      <dt class="text-2xl">Total:</dt>
                      <dd class="ml-5 text-2xl">{{ cartTotal }}&euro;</dd>
                    </div>
                  </dl>
                  <div class="flex justify-end">
                    <a href="/checkout"
                      class="block rounded bg-emerald-700 px-5 py-3 text-sm text-gray-100 transition hover:bg-emerald-800 text-white">
                      Checkout
                    </a>
                  </div>
                </div>
              </div>
            </div>
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
  data(){
    return {
      cartItems:[],
      Products:[],
    }
  },
  async mounted() {
        try {
            const response = await api.getCart() // wait for the Promise to resolve
            this.cartItems = response.data
            this.loading = false;
        } catch (error) {
            console.error(error)
            this.loading = true;
        }
        try {
            const response = await api.getProducts() // wait for the Promise to resolve
            this.Products = response.data
            this.loading = false;
        } catch (error) {
            console.error(error)
            this.loading = true;
        }
    },
    computed: {
    cartTotal() {
      return this.cartItems.reduce((total, item) => {
        const product = this.Products.find((p) => p.id === item.productId);
        if (product) {
          return total + (product.price * item.quantity);
        } else {
          return total;
        }
      }, 0);
    }
  },
  methods:{
    async removeItemFromCart(productId) {
      try {
        const response = await api.removeFromCart(productId);
        window.location.reload();
        console.log(response); // log the response for debugging
      } catch (error) {
        console.log(error); // log the error for debugging
      }
    },
    getProductName(productId) {
      const product = this.Products.find((p) => p.id === productId);
      return product ? product.name : "";
    },
    getProductQuanitity(productId) {
      const product = this.Products.find((p) => p.id === productId);
      return product ? product.quantity : "";
    },
    getProductDesc(productId) {
      const product = this.Products.find((p) => p.id === productId);
      return product ? product.description : "";
    },
  }

}
</script>
  