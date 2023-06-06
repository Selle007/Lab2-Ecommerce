<template>
    <div>
        <NuxtLayout name="admin">
            <template #header></template>
            <section class=" p-3 sm:p-5 w-max h-full">
        <div class="max-w-screen-xl px-4 lg:px-12">
                    <!-- Start coding here -->
                    <div class="bg-white relative shadow-md sm:rounded-lg overflow-hidden">
                        <div
                            class="flex flex-col md:flex-row items-center justify-between space-y-3 md:space-y-0 md:space-x-4 p-4">
                            <h2 class="mb-2 text-xl leading-none text-black md:text-2xl ">All Messages</h2>
                        </div>
                        <div class="overflow-x-auto">
                            <table class="w-full text-sm text-left text-gray-500">
                                <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                                    <tr>
                                        <th scope="col" class="px-4 py-3 text-left w-1/5">Message ID</th>
                                        <th scope="col" class="text-left w-1/5">Username</th>
                                        <th scope="col" class="text-left w-1/5">Email</th>
                                        <th scope="col" class="text-left w-1/5">Phone</th>
                                        <th scope="col" class="text-left w-1/5">Message</th>
                                        <th scope="col" class="text-left w-24">Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class="border-b" v-for="msg in Messages" :key="msg.id">
                                        <th scope="row" class="px-4 py-3 font-medium text-gray-900 whitespace-nowrap">
                                            {{ msg.id }}
                                        </th>
                                        <td class="text-left">{{ msg.name }}</td>
                                        <td class="text-left">{{ msg.email }}</td>
                                        <td class="text-left">{{ msg.phone }}</td>
                                        <td class="text-left">{{ msg.message }}</td>


                                        <td class="px-4 py-3 flex flex-row ">
                                            <span
                                                class="inline-flex divide-x overflow-hidden rounded-md border bg-white shadow-sm">
                                                <button
                                                    class="inline-block p-3 text-gray-700 hover:text-emerald-600 hover:bg-gray-50 focus:relative"
                                                    title="Edit Product" @click="detailMessage(msg.id)">
                                                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                                                        stroke-width="1.5" stroke="currentColor" class="h-4 w-4">
                                                        <path stroke-linecap="round" stroke-linejoin="round"
                                                            d="M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L10.582 16.07a4.5 4.5 0 01-1.897 1.13L6 18l.8-2.685a4.5 4.5 0 011.13-1.897l8.932-8.931zm0 0L19.5 7.125M18 14v4.75A2.25 2.25 0 0115.75 21H5.25A2.25 2.25 0 013 18.75V8.25A2.25 2.25 0 015.25 6H10" />
                                                    </svg>
                                                </button>

                                            </span>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div>
                                <div
                                    class="px-3 py-1 text-xs font-medium leading-none text-center text-emerald-800 bg-emerald-200 rounded-full animate-pulse">
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
      Messages: [],
    }
  },
  async mounted() {
    try {
      const response = await api.getContacts() // wait for the Promise to resolve
      this.Messages = response.data
      console.log(this.Messages);
      this.loading = false;
    } catch (error) {
      console.error(error)
      this.loading = true;
    }



  },
  methods: {
    detailMessage: function (id) {
      this.$router.push(`/dashboard/messages/${id}`);

    },

  }
}
</script>
