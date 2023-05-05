<template>
  <div>
    <NuxtLayout name="admin">
      <template #header></template>
      <section class="bg-gray-100 p-3 sm:p-5 w-screen">
        <div class="max-w-screen-xl px-4 lg:px-12">
          <!-- Start coding here -->
          <div class="bg-white relative shadow-md border sm:rounded-lg overflow-hidden">
            <div class="flex flex-col md:flex-row items-center justify-between space-y-3 md:space-y-0 md:space-x-4 p-4">
              <h2 class="mb-2 text-xl leading-none text-black md:text-2xl ">All Categories</h2>
              <div
                class="w-full md:w-auto flex flex-col md:flex-row space-y-2 md:space-y-0 items-stretch md:items-center justify-start md:space-x-3 flex-shrink-0">
                <div class="flex justify-center m-5">
                  <button id="defaultModalButton" data-modal-toggle="defaultModal"
                    class="inline-flex items-center px-5 py-2.5  text-sm font-medium text-center text-white bg-emerald-600 rounded-lg focus:ring-4 focus:ring-emerald-200 hover:bg-emerald-700"
                    type="button">
                    Create Category
                  </button>
                </div>
              </div>
            </div>
            <div class="overflow-x-auto">
              <table class="w-full text-sm text-left text-gray-500" v-if="!loading">
                <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                  <tr>
                    <th scope="col" class="px-4 py-3">Category Name</th>
                    <th scope="col" class="px-4 py-3 w-24">Actions</th>
                  </tr>
                </thead>
                <tbody>
                  <tr class="border-b" v-for="category in Categories" :key="category.id">
                    <th scope="row" class="px-4 py-3 font-medium text-gray-900 whitespace-nowrap">
                      {{ category.name }}
                    </th>


                    <td class="px-4 py-3 flex flex-row w-">
                      <span class="inline-flex divide-x overflow-hidden rounded-md border bg-white shadow-sm">
                        <button
                          class="inline-block p-3 text-gray-700 hover:bg-gray-50 hover:text-emerald-600 focus:relative"
                          title="Edit Product" @click="editCategory(category.id)">
                          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                            stroke="currentColor" class="h-4 w-4">
                            <path stroke-linecap="round" stroke-linejoin="round"
                              d="M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L10.582 16.07a4.5 4.5 0 01-1.897 1.13L6 18l.8-2.685a4.5 4.5 0 011.13-1.897l8.932-8.931zm0 0L19.5 7.125M18 14v4.75A2.25 2.25 0 0115.75 21H5.25A2.25 2.25 0 013 18.75V8.25A2.25 2.25 0 015.25 6H10" />
                          </svg>
                        </button>
                        <button class="inline-block p-3 text-gray-700 hover:bg-gray-50 hover:text-red-600 focus:relative"
                          title="Delete Product" @click.prevent="deleteCategory(category.id)">
                          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                            stroke="currentColor" class="h-4 w-4">
                            <path stroke-linecap="round" stroke-linejoin="round"
                              d="M14.74 9l-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 01-2.244 2.077H8.084a2.25 2.25 0 01-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 00-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 013.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 00-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 00-7.5 0" />
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



      <!-- CREATE modal -->
      <div id="defaultModal" tabindex="-1" aria-hidden="true"
        class="hidden overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-modal md:h-full backdrop-blur border">
        <div class="relative p-4 w-full max-w-2xl h-full md:h-auto">
          <!-- Modal content -->
          <div class="relative p-4 bg-white rounded-lg shadow dark:bg-gray-800 sm:p-5">
            <!-- Modal header -->
            <div class="flex justify-between items-center pb-4 mb-4 rounded-t border-b sm:mb-5 dark:border-gray-600">
              <h3 class="text-lg font-semibold text-gray-900 dark:text-white">
                Add Category
              </h3>
              <button type="button"
                class="text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm p-1.5 ml-auto inline-flex items-center dark:hover:bg-gray-600 dark:hover:text-white"
                data-modal-toggle="defaultModal">
                <svg aria-hidden="true" class="w-5 h-5" fill="currentColor" viewBox="0 0 20 20"
                  xmlns="http://www.w3.org/2000/svg">
                  <path fill-rule="evenodd"
                    d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                    clip-rule="evenodd"></path>
                </svg>
                <span class="sr-only">Close modal</span>
              </button>
            </div>
            <!-- Modal body -->
            <form @submit="createCategory()">
              <div class="grid gap-4 mb-4 sm:grid-cols-2">
                <div>
                  <label for="name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Category
                    Name</label>
                  <input type="text" name="name" id="name" v-model="category.name"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-emerald-600 focus:border-emerald-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-emerald-500 dark:focus:border-emerald-500"
                    placeholder="Type category name" required="">
                </div>

              </div>
              <button type="submit"
                class="inline-flex items-center px-5 py-2.5  text-sm font-medium text-center text-white bg-emerald-600 rounded-lg focus:ring-4 focus:ring-emerald-200 hover:bg-emerald-700">
                <svg class="mr-1 -ml-1 w-6 h-6" fill="currentColor" viewBox="0 0 20 20"
                  xmlns="http://www.w3.org/2000/svg">
                  <path fill-rule="evenodd"
                    d="M10 5a1 1 0 011 1v3h3a1 1 0 110 2h-3v3a1 1 0 11-2 0v-3H6a1 1 0 110-2h3V6a1 1 0 011-1z"
                    clip-rule="evenodd"></path>
                </svg>
                Create
              </button>
            </form>
          </div>
        </div>
      </div>


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
      Categories: [],
      category: {
        id: 'string',
        name: ''
      }
    }
  },
  async mounted() {
    try {
      const token = localStorage.getItem('token');
        console.log(token);
      const response = await api.getCategories() // wait for the Promise to resolve
      this.Categories = response.data
      console.log(this.Categories);
      this.loading = false;
    } catch (error) {
      console.error(error)
      this.loading = true;
    }



  },
  methods: {
    async createCategory() {
      try {
        const response = await api.createCategory({
          id: 'string',
          name: this.category.name
        })
        console.log(response.data)
        window.location.reload()
      } catch (error) {
        console.error(error)
      }
    },
    async deleteCategory(id) {
      try {
        const response = await api.deleteCategory(id)
        console.log(response)
        window.location.reload()
        console.log(id)

      } catch (error) {
        console.error(error)
        // handle error
      }
    },
    editCategory: function (id) {
      this.$router.push(`/dashboard/category/${id}`);

    },

  }
}
</script>