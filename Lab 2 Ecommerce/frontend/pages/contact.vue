<template>
    <div>
        <NuxtLayout name="client">
            <template #header></template>

            <section class="bg-gray-100">
                <div class="mx-auto max-w-screen-xl px-4 py-16 sm:px-6 lg:px-8">
                    <div class="grid grid-cols-1 gap-x-16 gap-y-8 lg:grid-cols-5">
                        <div class="lg:col-span-2 lg:py-12">
                            <img class="h-12" viewBox="0 0 28 24" fill="none" src="../assets/images/logo.png" />
                            <p class="max-w-xl text-lg">
                                At the same time, the fact that we are wholly owned and totally
                                independent from manufacturer and other group control gives you
                                confidence that we will only recommend what is right for you.
                            </p>

                            <div class="mt-8">
                                <a href="" class="text-2xl font-bold text-emerald-600 hover:text-emerald-800">
                                    049 111 222
                                </a>

                                <address class="mt-2 not-italic">
                                    212 Kevin Brook, Prishtine, XK 10000
                                </address>
                            </div>
                        </div>

                        <div class="rounded-lg bg-white p-8 shadow-lg lg:col-span-3 lg:p-12">
                            <form @submit.prevernt="createContact()"  class="space-y-4">
                                <div>
                                    <label class="sr-only" for="name">Name</label>
                                    <input class="w-full rounded-lg border shadow-md p-3 text-sm" placeholder="Name"
                                        type="text" id="name" v-model="message.name" required />
                                </div>

                                <div class="grid grid-cols-1 gap-4 sm:grid-cols-2">
                                    <div>
                                        <label class="sr-only" for="email">Email</label>
                                        <input class="w-full rounded-lg border shadow-md p-3 text-sm"
                                            placeholder="Email address" type="email" id="email"
                                            v-model="message.email"
                                            required />
                                    </div>

                                    <div>
                                        <label class="sr-only" for="phone">Phone</label>
                                        <input class="w-full rounded-lg border shadow-md p-3 text-sm"
                                            placeholder="Phone Number" type="tel" id="phone" 
                                            v-model="message.phone" required />
                                    </div>
                                </div>



                                <div>
                                    <label class="sr-only" for="message">Message</label>

                                    <textarea class="w-full rounded-lg border shadow-md p-3 text-sm" placeholder="Message"
                                    v-model="message.message" rows="8" id="message"  required></textarea>
                                </div>

                                <div class="mt-4">
                                    <button type="submit"
                                        class="inline-block w-full rounded-lg bg-emerald-600 px-5 py-3 font-medium text-white sm:w-auto hover:bg-emerald-700">
                                        Send Enquiry
                                    </button>
                                </div>
                            </form>
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
  data() {
    return {
      message: {
        id: 'string',
        name: '',
        email:'',
        phone:'',
        message:''
      }
    }
  },
  methods: {
    async createContact() {
      try {
        const response = await api.createContact({
          id: 'string',
          name: this.message.name,
          email: this.message.email,
          phone: this.message.phone,
          message: this.message.message
        })
        console.log(response.data)
        window.location.reload()
      } catch (error) {
        console.error(error)
      }
    },
  }
}
</script>