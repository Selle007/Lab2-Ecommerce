
<template>
  <div>
    <NuxtLayout name="admin">
      <template #header></template>
      <section class="p-6 my-6 w-screen">
        <div class="container grid grid-cols-1 gap-6 mx-auto sm:grid-cols-2 xl:grid-cols-4">
          <div class="flex p-4 space-x-4 rounded-lg md:space-x-6 border shadow-md">
            <div class="flex justify-center p-2 align-middle rounded-lg sm:p-4 dark:bg-emerald-400">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-9 h-9">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M6 6.878V6a2.25 2.25 0 012.25-2.25h7.5A2.25 2.25 0 0118 6v.878m-12 0c.235-.083.487-.128.75-.128h10.5c.263 0 .515.045.75.128m-12 0A2.25 2.25 0 004.5 9v.878m13.5-3A2.25 2.25 0 0119.5 9v.878m0 0a2.246 2.246 0 00-.75-.128H5.25c-.263 0-.515.045-.75.128m15 0A2.25 2.25 0 0121 12v6a2.25 2.25 0 01-2.25 2.25H5.25A2.25 2.25 0 013 18v-6c0-.98.626-1.813 1.5-2.122" />
              </svg>
            </div>
            <div class="flex flex-col justify-center align-middle">
              <p class="text-3xl font-semibold leading-none">{{ productCount }}</p>
              <p class="capitalize">Products</p>
            </div>
          </div>
          <div class="flex p-4 space-x-4 rounded-lg md:space-x-6  border shadow-md">
            <div class="flex justify-center p-2 align-middle rounded-lg sm:p-4 bg-emerald-400">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-9 h-9">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M2.25 3h1.386c.51 0 .955.343 1.087.835l.383 1.437M7.5 14.25a3 3 0 00-3 3h15.75m-12.75-3h11.218c1.121-2.3 2.1-4.684 2.924-7.138a60.114 60.114 0 00-16.536-1.84M7.5 14.25L5.106 5.272M6 20.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zm12.75 0a.75.75 0 11-1.5 0 .75.75 0 011.5 0z" />
              </svg>
            </div>
            <div class="flex flex-col justify-center align-middle">
              <p class="text-3xl font-semibold leading-none">{{ orderCount }}</p>
              <p class="capitalize">Orders</p>
            </div>
          </div>
          <div class="flex p-4 space-x-4 rounded-lg md:space-x-6 border shadow-md">
            <div class="flex justify-center p-2 align-middle rounded-lg sm:p-4 dark:bg-emerald-400">
              <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" fill="currentColor"
                class="h-9 w-9 dark:text-gray-800" data-darkreader-inline-fill=""
                style="--darkreader-inline-fill:currentColor;">
                <path
                  d="M256,16C123.452,16,16,123.452,16,256S123.452,496,256,496,496,388.548,496,256,388.548,16,256,16ZM403.078,403.078a207.253,207.253,0,1,1,44.589-66.125A207.332,207.332,0,0,1,403.078,403.078Z">
                </path>
                <path d="M256,384A104,104,0,0,0,360,280H152A104,104,0,0,0,256,384Z"></path>
                <polygon
                  points="205.757 228.292 226.243 203.708 168 155.173 109.757 203.708 130.243 228.292 168 196.827 205.757 228.292">
                </polygon>
                <polygon
                  points="285.757 203.708 306.243 228.292 344 196.827 381.757 228.292 402.243 203.708 344 155.173 285.757 203.708">
                </polygon>
              </svg>
            </div>
            <div class="flex flex-col justify-center align-middle">
              <p class="text-3xl font-semibold leading-none">{{ userCount }}</p>
              <p class="capitalize">New customers</p>
            </div>
          </div>
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
  data(){
    return{
      Products:[],
      Orders:[],
      Users:[],
    }
  },
  async mounted(){
    try {
      const response = await api.getProducts()
      this.Products = response.data
    } catch (error) {
      console.error(error)
    }
    try {
      const response = await api.getOrders()
      this.Orders = response.data
    } catch (error) {
      console.error(error)
    }
    try {
      const response = await api.getUsers()
      this.Users = response.data
    } catch (error) {
      console.error(error)
    }
  },
  computed: {
    orderCount() {
      return this.Orders.length;
    },
    productCount() {
      return this.Products.length;
    },
    userCount() {
      return this.Users.length;
    },
  },

}
</script>