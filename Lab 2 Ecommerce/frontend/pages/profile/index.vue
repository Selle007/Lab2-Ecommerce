<template>
    <div>
        <NuxtLayout name="client">
            <template #header></template>

            <section>
                <div class="relative mx-auto max-w-screen-xl px-4 py-8">
                    <div class="grid gap-8  lg:items-center">
                        <div v-if="user">
                            <div class="relative mt-4 flex justify-center">

                                <div class="lg:sticky lg:top-0">
                                    <div class="space-y-4 ">
                                        <div>
                                            <h1 class="text-2xl font-bold lg:text-3xl">User Profile</h1>

                                        </div>
                                        <div>
                                            <p class="mt-1 text-sm text-gray-500">User ID: {{ user.id }}</p>
                                        </div>
                                        <div>
                                            <legend class="text-lg font-bold">Username</legend>
                                            <p class="mt-1 text-sm text-gray-500"> {{ user.userName }} </p>
                                        </div>
                                        <div>
                                            <legend class="text-lg font-bold">Email</legend>
                                            <p class="mt-1 text-sm text-gray-500">{{ user.email }}</p>
                                        </div>


                                        <button @click="editProfile(user.id)"
                                            class="block w-full rounded bg-emerald-600 p-2 text-sm font-medium transition hover:scale-105 text-white">
                                            Edit User </button>
                                        
                                        <a href="/orders">
                                            <button
                                                class="block w-full rounded border border-emerald-600 p-2 mt-2 text-sm font-medium transition hover:scale-105 text-emerald">
                                                View Orders </button>
                                        </a>
                                        <a href="/wishlist">
                                            <button
                                                class="block w-full rounded border border-emerald-600 p-2 mt-2 text-sm font-medium transition hover:scale-105 text-emerald">
                                                Wishlist </button>
                                        </a>

                                    </div>
                                </div>
                            </div>

                        </div>

                        <div role="status" class="flex justify-center" v-else>
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
                    </div>

                </div>
            </section>

            <template #footer></template>
        </NuxtLayout>
    </div>
</template>
  
<script>
import api from '@/services/api'
import Cookies from 'js-cookie'

export default {
    head() {
        return {
            layout: false,
        };
    },
    data() {
        return {
            user: null,
        };
    },
    mounted() {
        // Check if the authentication token is present
        let token = Cookies.get('token');

        if (token) {
            // Fetch the user profile if the token exists
            setTimeout(this.fetchUserProfile, 500);
        } else {
            // Redirect to the login page or show an error message
            // depending on your application's requirements
            console.error('User not logged in');
        }
    },
    methods: {
        async fetchUserProfile() {
            try {
                const response = await api.getProfile();
                this.user = response.data;
            } catch (error) {
                console.error('Error retrieving user profile:', error);
            }
        },
        editProfile: function (id) {
      this.$router.push(`/profile/${id}`);

    },
        getAuthToken() {
            // Get the authentication token from cookies or any other storage mechanism
            // Return the token if it exists, otherwise return null
            return document.cookie.replace(/(?:(?:^|.*;\s*)authToken\s*\=\s*([^;]*).*$)|^.*$/, '$1') || null;
        },
    },
};
</script>
  