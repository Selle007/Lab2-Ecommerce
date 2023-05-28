<template>
  <div>
    <NuxtLayout name="admin">
      <template #header></template>
      <section class="bg-gray-100 p-3 sm:p-5 w-screen">
        <div class="max-w-screen-xl px-4 lg:px-12">
          <!-- Start coding here -->
          <div class="bg-white relative shadow-md border sm:rounded-lg overflow-hidden">
            <div class="flex flex-col md:flex-row items-center justify-between space-y-3 md:space-y-0 md:space-x-4 p-4">
              <h2 class="mb-2 text-xl leading-none text-black md:text-2xl ">All Orders</h2>
              <div
                class="w-full md:w-auto flex flex-col md:flex-row space-y-2 md:space-y-0 items-stretch md:items-center justify-start md:space-x-3 flex-shrink-0">
              </div>
            </div>
            <div class="overflow-x-auto">
              <table class="w-full text-sm text-left text-gray-500" v-if="!loading">
                <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                  <tr>
                    <th scope="col" class="px-4 py-3 text-left w-1/5">Order ID</th>
                    <th scope="col" class="text-left w-1/5">Shipping Details</th>
                    <th scope="col" class="text-left w-1/5">Created At</th>
                    <th scope="col" class="text-left w-1/5">Total</th>
                    <th scope="col" class="text-left w-1/5">Status</th>
                    <th scope="col" class="text-left w-24">Actions</th>
                  </tr>
                </thead>
                <tbody>
                  <tr class="border-b" v-for="order in Orders" :key="order.id">
                    <th scope="row" class="px-4 py-3 font-medium text-gray-900 whitespace-nowrap">
                      {{ order.id }}
                    </th>
                    <td class="text-left">TEST
                    </td>
                    <td class="text-left">{{ formatDate(order.created_at) }}</td>
                    <td class="text-left">{{ order.total }}&euro;</td>
                    <td class="text-left">
                      <span v-if="order.status === 'Processing'"
                        class="py-2 bg-indigo-100 text-indigo-800 text-xs font-medium mr-2 px-2.5 py-0.5 rounded-full dark:bg-indigo-900 dark:text-indigo-300">Processing</span>
                      <span v-if="order.status === 'Shipped'"
                        class="py-2 bg-yellow-100 text-yellow-800 text-xs font-medium mr-2 px-2.5 py-0.5 rounded-full dark:bg-yellow-900 dark:text-yellow-300">Shipped</span>
                      <span v-if="order.status === 'Completed'"
                        class="py-2 bg-green-100 text-green-800 text-xs font-medium mr-2 px-2.5 py-0.5 rounded-full dark:bg-green-900 dark:text-green-300">Completed</span>
                    </td>


                    <td class="px-4 py-3 flex flex-row ">
                      <span class="inline-flex divide-x overflow-hidden rounded-md border bg-white shadow-sm">
                        <button
                          class="inline-block p-3 text-gray-700 hover:text-emerald-600 hover:bg-gray-50 focus:relative"
                          title="Edit Product" @click="viewOrder(order.id)">
                          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                            stroke="currentColor" class="h-4 w-4">
                            <path stroke-linecap="round" stroke-linejoin="round"
                              d="M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L10.582 16.07a4.5 4.5 0 01-1.897 1.13L6 18l.8-2.685a4.5 4.5 0 011.13-1.897l8.932-8.931zm0 0L19.5 7.125M18 14v4.75A2.25 2.25 0 0115.75 21H5.25A2.25 2.25 0 013 18.75V8.25A2.25 2.25 0 015.25 6H10" />
                          </svg>
                        </button>

                      </span>
                    </td>
                  </tr>
                </tbody>
              </table>
              <div v-else>
                <div
                  class="px-3 py-1 text-xs font-medium  leading-none text-center text-emerald-800 bg-emerald-200 rounded-full animate-pulse">

                  Loading...
                </div>
              </div>
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
  data() {
    return {
      loading: true,
      Orders: [],
    }
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
      const response = await api.getOrders() // wait for the Promise to resolve
      this.Orders = response.data
      console.log(this.Orders);
      this.loading = false;
    } catch (error) {
      console.error(error)
      this.loading = true;
    }



  },


  methods: {
    async createProduct() {
      try {
        const token = localStorage.getItem('token');
        console.log(token);

        const response = await api.createProduct({
          id: 'string',
          name: this.product.name,
          description: this.product.description,
          price: this.product.price,
          stock: this.product.stock,
          isFeatured: this.product.isFeatured,
          categoryId: this.product.category,
          image: this.product.image,
        });

        console.log(response.data);
        window.location.reload();
      } catch (error) {
        console.error(error);
      }
    },



    async deleteProduct(id) {
      try {
        const response = await api.deleteProduct(id);
        console.log(response)
        window.location.reload()
        console.log(id)

      } catch (error) {
        console.error(error)
        // handle error
      }
    },

    viewOrder: function (id) {
      this.$router.push(`/dashboard/order/${id}`);

    },
    getCategoryName(categoryId) {
      const category = this.Categories.find((c) => c._id === categoryId);
      return category ? category.name : "";
    },
    
    formatDate(date) {
            // format the date string to display in a more user-friendly way
            return new Date(date).toLocaleDateString()
        },

  }
}
</script>