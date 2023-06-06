<template>
    <div>
        <NuxtLayout name="client">
            <template #header></template>
            <section class="bg-white w-screen">
                <div class="py-8 px-4 mx-auto max-w-2xl lg:py-16">
                    <h2 class="mb-4 text-xl font-bold text-gray-900">Edit User Details</h2>
                    <form @submit.prevent="handleUpdateForm">
                        <div class="grid gap-4 sm:grid-cols-2 sm:gap-6">
                            <div class="sm:col-span-2">
                                <label for="categoryName"
                                    class="relative block overflow-hidden rounded-md border border-gray-200 px-3 pt-3 shadow-sm focus-within:border-blue-600 focus-within:ring-1 focus-within:ring-blue-600">
                                    <input type="text" id="categoryName" placeholder="Username"
                                        class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"
                                        v-model="user.userName" required />

                                    <span
                                        class="absolute left-3 top-3 -translate-y-1/2 text-xs text-gray-700 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                                        Username
                                    </span>
                                </label>
                            </div>
                            <div class="sm:col-span-2">
                                <label for="categoryName"
                                    class="relative block overflow-hidden rounded-md border border-gray-200 px-3 pt-3 shadow-sm focus-within:border-blue-600 focus-within:ring-1 focus-within:ring-blue-600">
                                    <input type="text" id="categoryName" placeholder="Email"
                                        class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"
                                        v-model="user.email" required />

                                    <span
                                        class="absolute left-3 top-3 -translate-y-1/2 text-xs text-gray-700 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                                        Email
                                    </span>
                                </label>
                            </div>
                        </div>
                        <button
                            class="inline-flex items-center px-5 py-2.5 mt-4 sm:mt-6 text-sm font-medium text-center text-white bg-emerald-600 rounded-lg focus:ring-4 focus:ring-primary-200 hover:bg-emerald-700">
                            Edit
                        </button>
                    </form>
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
            user:{},
        };
    },
    async mounted() {
        try {
            let userId = this.$route.params.id
            const response = await api.getProfile() // wait for the Promise to resolve
            this.user = response.data
            this.loading = false;
        } catch (error) {
            console.error(error)
            this.loading = true;
        }
    },
    methods: {
        async handleUpdateForm() {
            const userId = this.user.id;
            try {
                const response = await api.updateProfile(userId, this.user);
                this.$router.push(`/profile`);
            } catch (error) {
                console.error(error);
            }
        },
    },
}
</script>
  