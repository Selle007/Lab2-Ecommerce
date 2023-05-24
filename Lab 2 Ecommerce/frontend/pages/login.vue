<template>
    <div>
        <NuxtLayout name="client">
            <template #header></template>

            <div class="flex min-h-full items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
                <div class="w-full max-w-md space-y-8">
                    <div>
                        <img class="mx-auto h-12 w-auto" src="../assets/images/logo.png" alt="Your Company" />
                        <h2 class="mt-6 text-center text-3xl font-bold tracking-tight text-gray-900">
                            Login to your account
                        </h2>

                    </div>

                    <input type="hidden" name="remember" value="true" />
                    <div class="-space-y-px rounded-md shadow-sm">
                        <div>
                            <label for="email-address" class="sr-only">Email address</label>
                            <input id="email-address" name="email" type="email" autocomplete="email" required=""
                                v-model="email"
                                class="relative block w-full appearance-none rounded-none rounded-t-md border border-gray-300 px-3 py-2 text-gray-900 placeholder-gray-500 focus:z-10 focus:border-emerald-500 focus:outline-none focus:ring-emerald-500 sm:text-sm"
                                placeholder="Email address" />
                        </div>
                        <div>
                            <label for="password" class="sr-only">Password</label>
                            <input id="password" name="password" type="password" autocomplete="current-password" required=""
                                v-model="password"
                                class="relative block w-full appearance-none rounded-none rounded-b-md border border-gray-300 px-3 py-2 text-gray-900 placeholder-gray-500 focus:z-10 focus:border-emerald-500 focus:outline-none focus:ring-emerald-500 sm:text-sm"
                                placeholder="Password" />
                        </div>
                    </div>

                    <div class="flex items-center justify-between">
                        <div class="flex items-center">
                            <input id="remember-me" name="remember-me" type="checkbox"
                                class="h-4 w-4 rounded border-gray-300 text-emerald-600 focus:ring-emerald-500" />
                            <label for="remember-me" class="ml-2 block text-sm text-gray-900">Remember me</label>
                        </div>

                        <div class="text-sm">
                            <a href="#" class="font-medium text-emerald-600 hover:text-emerald-500">Forgot your
                                password?</a>
                        </div>
                    </div>

                    <div>
                        <button type="submit"
                            class="group relative flex w-full justify-center rounded-md border border-transparent bg-emerald-600 py-2 px-4 text-sm font-medium text-white hover:bg-emerald-700 focus:outline-none focus:ring-2 focus:ring-emerald-500 focus:ring-offset-2"
                            @click="login">
                            Login
                        </button>
                    </div>
                    <div class="text-sm text-center">
                        <a href="/register" class="font-medium text-emerald-600 hover:text-emerald-500">Don't have an
                            account? Register now!</a>
                    </div>
                </div>
            </div>

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
        }
    },
    data() {
        return {
            email: '',
            password: ''
        }
    },
    methods: {
        async login() {
            try {
                const response = await api.login({
                    email: this.email,
                    password: this.password
                })
                // Save the token to local storage

                // localStorage.setItem('token', response.data.token)

                // Set the token as a cookie
                Cookies.set('token', response.data.token, { expires: 1 }) // Expires in 7 days


                // Redirect to the home page or any other page after successful login
                this.$router.push('/')
            } catch (error) {
                // Show an alert message if login fails
                alert('Login failed. Please check your credentials and try again.')
            }
        }

    },

}
</script>
