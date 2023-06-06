<template>
  <div>
    <NuxtLayout name="admin">
      <template #header></template>
      <section class=" p-3 sm:p-5 w-max h-full">
        <div class="max-w-screen-xl px-4 lg:px-12">
          <!-- Start coding here -->
          <div class="bg-white relative shadow-md border sm:rounded-lg overflow-hidden">
            <div class="flex flex-col md:flex-row items-center justify-between space-y-3 md:space-y-0 md:space-x-4 p-4">
              <h2 class="mb-2 text-xl leading-none text-black md:text-2xl ">All Users</h2>
              <div
                class="w-full md:w-auto flex flex-col md:flex-row space-y-2 md:space-y-0 items-stretch md:items-center justify-start md:space-x-3 flex-shrink-0">
              </div>
            </div>
            <div class="overflow-x-auto">
              <table class="w-full text-sm text-left text-gray-500" v-if="!loading">
                <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                  <tr>
                    <th scope="col" class="px-4 py-3 text-left w-1/5">User ID</th>
                    <th scope="col" class="text-left w-1/5">Username</th>
                    <th scope="col" class="text-left w-1/5">Email</th>
                    <th scope="col" class="text-left w-1/5">Role</th>
                    <th scope="col" class="text-left w-24">Actions</th>
                  </tr>
                </thead>
                <tbody>
                  <tr class="border-b" v-for="user in Users" :key="user.id">
                    <th scope="row" class="px-4 py-3 font-medium text-gray-900 whitespace-nowrap">
                      {{ user.id }}
                    </th>
                    <td class="text-left">{{ user.userName }}</td>
                    <td class="text-left">{{ user.email }}</td>
                    <td class="text-left">{{ user.roles }}</td>



                    <td class="px-4 py-3 flex flex-row ">
                      <span class="inline-flex divide-x overflow-hidden rounded-md border bg-white shadow-sm">
                        <button
                          class="inline-block p-3 text-gray-700 hover:text-emerald-600 hover:bg-gray-50 focus:relative"
                          title="Edit Product" @click="changeRole(user.id)">
                          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                            stroke="currentColor" class="h-4 w-4">
                            <path stroke-linecap="round" stroke-linejoin="round"
                              d="M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L10.582 16.07a4.5 4.5 0 01-1.897 1.13L6 18l.8-2.685a4.5 4.5 0 011.13-1.897l8.932-8.931zm0 0L19.5 7.125M18 14v4.75A2.25 2.25 0 0115.75 21H5.25A2.25 2.25 0 013 18.75V8.25A2.25 2.25 0 015.25 6H10" />
                          </svg>
                        </button>
                        <button class="inline-block p-3 text-gray-700 hover:bg-gray-50 hover:text-red-600 focus:relative"
                          title="Delete Product" @click.prevent="deleteUser(user.id)">
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
      Users: [],
    }
  },
  async mounted() {
    try {
      const response = await api.getUsers() // wait for the Promise to resolve
      this.Users = response.data
      this.loading = false;
    } catch (error) {
      console.error(error)
      this.loading = true;
    }
  },
  methods: {
    async deleteUser(userId) {
      try {
        
        await api.deleteUser(userId);
        // If the deletion is successful, you can update the Users array to reflect the changes.
        this.Users = this.Users.filter(user => user.id !== userId);
      } catch (error) {
        console.error(error);
      }
    },
    async changeRole(userId) {
      try {
        
        await api.updateUserRole(userId);
        // If the deletion is successful, you can update the Users array to reflect the changes.
        window.location.reload()
      } catch (error) {
        console.error(error);
      }
    },
  }
}
</script>