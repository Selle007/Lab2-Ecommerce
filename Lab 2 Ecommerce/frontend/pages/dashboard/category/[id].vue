<template>
  <div>
    <NuxtLayout name="admin">
      <template #header></template>
      <section class="bg-white w-screen">
        <div class="py-8 px-4 mx-auto max-w-2xl lg:py-16">
          <h2 class="mb-4 text-xl font-bold text-gray-900">Edit Category</h2>
          <form @submit.prevent="handleUpdateForm">
            <div class="grid gap-4 sm:grid-cols-2 sm:gap-6">
              <div class="sm:col-span-2">
                <label for="categoryName"
                  class="relative block overflow-hidden rounded-md border border-gray-200 px-3 pt-3 shadow-sm focus-within:border-blue-600 focus-within:ring-1 focus-within:ring-blue-600">
                  <input type="text" id="categoryName" placeholder="Category Name"
                    class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"
                    v-model="name" required />

                  <span
                    class="absolute left-3 top-3 -translate-y-1/2 text-xs text-gray-700 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Category Name
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
      category: {},
      name: '', // add the name property
    };
  },
  async mounted(){
    try {
      let categotyId = this.$route.params.id
      const response = await api.getCategoryById(categotyId) // wait for the Promise to resolve
      this.category = response.data
      this.name = this.category.name // set the initial value of the input field to the category name
      console.log(this.category);
      this.loading = false;
    } catch (error) {
      console.error(error)
      this.loading = true;
    }
  },
  methods: {
    async handleUpdateForm() {
      const categoryId = this.category.id;
      const categoryData = { id:categoryId, name: this.name };
      try {
        const response = await api.updateCategory(categoryId, categoryData);
        console.log(response);
        // redirect to the updated category page
        this.$router.push(`/dashboard/category/list-categories`);
      } catch (error) {
        console.error(error);
      }
    },
  },
}
</script>
