<template>
  <div>
    <NuxtLayout name="admin">
      <template #header></template>
      <section class="bg-gray-100 w-screen">
    <div class="py-8 px-4 mx-auto max-w-2xl lg:py-16">
      <form @submit.prevent="handleUpdateForm">
        <div class=" px-4 mx-auto max-w-2xl ">
          <h2 class="mb-2 text-xl leading-none text-black md:text-2xl ">Message Id: {{ message.id }}</h2>

         
          <dl class="mt-6">
            <dt class="mb-2 font-semibold leading-none text-black">Name: {{ message.name }}</dt>
          </dl>
          <dl class="mt-6">
            <dt class="mb-2 font-semibold leading-none text-black">Email: {{ message.email }}</dt>

          </dl>
          <dl class="mt-6">
            <dt class="mb-2 font-semibold leading-none text-black">Phone: {{ message.phone }}</dt>

          </dl>
          <dl class="mt-6">
            <dt class="mb-2 font-semibold leading-none text-black">Message: {{ message.message }}</dt>

          </dl>

        </div>
        <button
          class="inline-flex items-center px-5 py-2.5 text-sm font-medium text-center text-white bg-emerald-600 rounded-lg focus:ring-4 focus:ring-primary-200 hover:bg-emerald-700"
        >
          Back to list
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
      message: {},
    };
  },
  async mounted(){
    try {
      let contactId = this.$route.params.id
      const response = await api.getContactById(contactId) // wait for the Promise to resolve
      this.message = response.data
    } catch (error) {
      console.error(error)
    }
  },
  methods: {
    async handleUpdateForm() {
      this.$router.push("/dashboard/messages/list-messages");
    },
  },
}
</script>
