<template>
    <nav class="bg-white border-gray-200 dark:bg-gray-900">
        <div class="flex flex-wrap justify-between items-center mx-auto max-w-screen-xl p-4">
            <a href="/" class="flex items-center">
                <img src="../assets/images/logo.png" class="h-8 mr-3" alt="Flowbite Logo" />

            </a>
            <div class="flex items-center">
                <a href="tel:38349111222" class="mr-6 text-sm  text-gray-500 dark:text-white hover:text-emerald-600">(383)
                    49-111-222</a>
                <a href="/login" v-if="!isLoggedIn"
                    class="text-sm  text-emerald-600 dark:text-emerald-500 hover:text-emerald-600">Login</a>
                <a href="/" @click="logout" v-if="isLoggedIn"
                    class="text-sm  text-emerald-600 dark:text-emerald-500 hover:text-emerald-600">Logout</a>
            </div>
        </div>
    </nav>
    <nav class="bg-gray-50 dark:bg-gray-700">
        <div class="max-w-screen-xl px-4 py-3 mx-auto">
            <div class="flex justify-center">
                <ul class="flex flex-row  text-center font-medium mt-0 mr-6 space-x-8 text-sm">
                    <li>
                        <a href="/" class="text-gray-900 dark:text-white hover:text-emerald-600"
                            aria-current="page">Home</a>
                    </li>
                    <li>
                        <Menu as="div" class="relative text-left">
                            <div>
                                <MenuButton
                                    class="inline-flex justify-center text-gray-900 transition hover:text-emerald-600">
                                    Products
                                </MenuButton>
                            </div>

                            <transition enter-active-class="transition ease-out duration-100"
                                enter-from-class="transform opacity-0 scale-95"
                                enter-to-class="transform opacity-100 scale-100"
                                leave-active-class="transition ease-in duration-75"
                                leave-from-class="transform opacity-100 scale-100"
                                leave-to-class="transform opacity-0 scale-95">
                                <MenuItems
                                    class="absolute z-10 mt-2 w-56 origin-top-right divide-y divide-gray-100 rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                                    <div class="py-1">
                                        <MenuItem>
                                        <a href="`/category/${category._id}`" :class="[
                                                active ? 'bg-gray-100 text-gray-900' : 'text-gray-700',
                                                'block px-4 py-2 text-sm hover:text-emerald-600',
                                            ]">TEST</a>
                                        </MenuItem>
                                    </div>
                                </MenuItems>
                            </transition>
                        </Menu>
                    </li>
                    <li>
                        <a href="/about" class="text-gray-900 dark:text-white hover:text-emerald-600">About</a>
                    </li>
                    <li>
                        <a href="/contact" class="text-gray-900 dark:text-white hover:text-emerald-600">Contact</a>
                    </li>
                    <li>
                        <a href="/dashboard" class="text-gray-900 dark:text-white hover:text-emerald-600">Dashboard</a>
                    </li>
                    <li>
                        <a href="/cart" class="text-gray-900 dark:text-white hover:text-emerald-600">cart</a>
                    </li>
                    <li>
                        <a href="/checkout" class="text-gray-900 dark:text-white hover:text-emerald-600">checkout</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>
  
<script>
import { Menu, MenuButton, MenuItems, MenuItem } from '@headlessui/vue'
import api from '@/services/api'

export default {
    components: {
        Menu,
        MenuButton,
        MenuItem,
        MenuItems,
    },
    data() {
        return {
            isLoggedIn: false
        }
    },
    methods: {
        async logout() {
            try {
                await api.logout()
                 // clear token from local storage
                this.isLoggedIn = false // update isLoggedIn state
            } catch (error) {
                // handle error
            }
        },
        goToLogin() {
            this.$router.push('/login')
        }
    },
    mounted() {
        if (localStorage.getItem('token')) {
            // user is logged in
            this.isLoggedIn = true;
        } else {
            // user is not logged in
            this.isLoggedIn = false;
        }
    }

}
</script>
  
<style scoped></style>
  