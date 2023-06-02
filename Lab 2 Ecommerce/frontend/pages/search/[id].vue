
<template>
    <div>
        <NuxtLayout name="client">
            <template #header></template>

            <div class="flex flex-row m-auto w-11/12 h-fit">

                <section class="w-1/5 bg-white mt-28 border rounded-lg h-fit">
                    <!-- category v-for goes in nav below -->
                    <nav aria-label="Main Nav" class="flex flex-col space-y-1 py-2" v-for="category in Categories"
                        :key="category.id">
                        <a :href="`/category/${category.id}`"
                            class="block rounded-lg  px-4 py-2 text-sm font-medium text-gray-700 hover:text-emerald-600">
                            {{ category.name }}
                        </a>
                    </nav>

                </section>
                <!--Products-->
                <section class="bg-white w-full">
                    <div class="max-w-screen-xl px-4 py-8 mx-auto sm:px-6 sm:py-12 lg:px-8">
                        <header  class="text-center">
                            <h2 v-if="Products.length < 1" class="text-xl font-bold text-gray-900 sm:text-3xl">No Products found!</h2>
                        </header>

                        <ul class="grid gap-4 mt-8 sm:grid-cols-2 lg:grid-cols-4">
                            <li class="shadow-md border rounded-lg" v-for="product in Products" :key="product.id">
                                <ProductCard :product="product" />
                            </li>
                        </ul>
                    </div>
                </section>
            </div>
            <template #footer></template>
        </NuxtLayout>
    </div>
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
            Categories: [],
            category:{},

        }
    },
    async mounted() {
        const query = this.$route.params.id;
      if (query) {
        try {
          const response = await api.searchProducts(query);
          this.Products = response.data;
        } catch (error) {
          console.error(error);
        }
      }
        try {
            const response = await api.getCategories() // wait for the Promise to resolve
            this.Categories = response.data
            this.loading = false;
        } catch (error) {
            console.error(error)
            this.loading = true;
        }

    },
    computed: {
    filteredProducts() {
      return this.Products.filter(
        (product) => product.categoryId === this.$route.params.id
      );
    },
  },
}

</script>
  