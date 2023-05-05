<template>
    <section class="bg-gray-100">
        <div class="max-w-screen-xl px-4 py-8 mx-auto sm:px-6 sm:py-12 lg:px-8">
            <header class="text-center">
                <h2 class="text-xl font-bold text-gray-900 sm:text-3xl">Featured Products</h2>
            </header>

            <ul class="grid gap-4 mt-8 sm:grid-cols-2 lg:grid-cols-4">
                <li v-for="product in Products" :key="product.id" class="shadow-md border rounded-lg">
                    <ProductCard :product="product"/>
                </li>
                


            </ul>
        </div>
    </section>
</template>

<script>
import ProductCard from '~/components/ProductCard.vue'
import api from '@/services/api'

export default {
    components: {
        ProductCard,
    },
    data() {
        return {
            Products: [],
        }
    },
    async mounted() {
        try {
            const response = await api.getProducts() // wait for the Promise to resolve
            this.Products = response.data
            console.log(this.Products);
            this.loading = false;
        } catch (error) {
            console.error(error)
            this.loading = true;
        }
    }
}

</script>

<style></style>