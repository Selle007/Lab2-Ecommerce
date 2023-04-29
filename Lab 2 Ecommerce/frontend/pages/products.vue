<template>
  <div>
    <NuxtLayout name="client">
      <template #header></template>

      <div class="flex flex-row m-auto w-11/12 h-fit">

        <section class="w-1/5 bg-white mt-28 border rounded-lg h-fit">
          <!-- category v-for goes in nav below -->
          <nav aria-label="Main Nav" class="flex flex-col space-y-1 py-2">
            <a href="/category"
              class="block rounded-lg  px-4 py-2 text-sm font-medium text-gray-700 hover:text-emerald-600">
              test
            </a>
          </nav>

        </section>
        <!--Products-->
        <section class="bg-gray-50 w-full">
          <div class="max-w-screen-xl px-4 py-8 mx-auto sm:px-6 sm:py-12 lg:px-8">
            <header class="text-center">
              <h2 class="text-xl font-bold text-gray-900 sm:text-3xl">test</h2>
            </header>

            <ul class="grid gap-4 mt-8 sm:grid-cols-2 lg:grid-cols-4">
              <li class="shadow-md border rounded-lg">
                <a href="/product" class="group relative block overflow-hidden">
                  <button
                    class="absolute right-4 top-4 z-10 rounded-full bg-white p-1.5 text-gray-900 transition hover:text-gray-900/75">
                    <span class="sr-only">Wishlist</span>

                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                      stroke="currentColor" class="h-4 w-4">
                      <path stroke-linecap="round" stroke-linejoin="round"
                        d="M21 8.25c0-2.485-2.099-4.5-4.688-4.5-1.935 0-3.597 1.126-4.312 2.733-.715-1.607-2.377-2.733-4.313-2.733C5.1 3.75 3 5.765 3 8.25c0 7.22 9 12 9 12s9-4.78 9-12z" />
                    </svg>
                  </button>

                  <img src="../assets/images/3.png" alt=""
                    class="h-64 aspect-ratio object-cover transition duration-500 group-hover:scale-105 sm:h-72" />

                  <div class="relative border border-gray-100 bg-white p-6">

                    <h3 class="mt-4 text-lg font-medium text-gray-900">123asdasd</h3>

                    <p class="mt-1.5 text-sm text-gray-700">asdasd</p>
                    <div class="card-content flex-1">
                      <h3 class="mt-4 text-lg font-medium text-gray-900">10.00&euro;</h3>

                      <form class="mt-4">
                        <button
                          class="block w-full rounded bg-emerald-600 p-4 text-sm font-medium transition hover:scale-105 text-white">
                          Add to Cart </button>
                      </form>
                    </div>
                  </div>

                </a>
              </li>
            </ul>
          </div>
        </section>
      </div>
      <template #footer></template>
    </NuxtLayout>
  </div>
</template>

<script setup>
definePageMeta({
  layout: false,
});
</script>