<template>
    <div>
        <NuxtLayout name="client">
            <template #header></template>

            <div class="flex min-h-full items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
                <div class="w-full max-w-md space-y-8">
                    <div>
                        <img class="mx-auto h-12 w-auto" src="../assets/images/logo.png" alt="Your Company" />
                        <h2 class="mt-6 text-center text-3xl font-bold tracking-tight text-gray-900">
                            Create an account
                        </h2>
                    </div>

                    <input type="hidden" name="remember" value="true" />
                    <div class="-space-y-px rounded-md shadow-sm">
                        <div>
                            <label for="email-address" class="sr-only">Email address</label>
                            <input id="email-address" name="email" v-model="email" type="email" autocomplete="email"
                                required=""
                                class="relative block w-full appearance-none rounded-none rounded-t-md border border-gray-300 px-3 py-2 text-gray-900 placeholder-gray-500 focus:z-10 focus:border-emerald-500 focus:outline-none focus:ring-emerald-500 sm:text-sm"
                                placeholder="Email address" />
                        </div>
                        <div>
                            <label for="password" class="sr-only">Password</label>
                            <input id="password" name="password" v-model="password" type="password"
                                autocomplete="current-password" required=""
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
                            @click="register">
                            <span class="absolute inset-y-0 left-0 flex items-center pl-3">
                                <LockClosedIcon class="h-5 w-5 text-emerald-500 group-hover:text-emerald-400"
                                    aria-hidden="true" />
                            </span>
                            Register
                        </button>
                    </div>
                    <div class="text-sm text-center">
                        <a href="/login" class="font-medium text-emerald-600 hover:text-emerald-500">Already have account?
                            Login now!</a>
                    </div>
                </div>
            </div>

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
      email: '',
      password: ''
    }
  },
  methods: {
    async register() {
      try {
        const response = await api.register({
          email: this.email,
          password: this.password
        })
        // Handle the response here
        this.$router.push('/login')
      } catch (error) {
        // Handle the error here
        alert('Registration failed. Please try again.')
      }
    }
  }
}
</script>
