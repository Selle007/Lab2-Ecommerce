<template>
  <div>
    <NuxtLayout name="client">
      <template #header></template>
      <section class="py-6 bg-gray-50 text-gray-900">
		<div class="container flex flex-col items-center justify-center p-4 mx-auto space-y-8 sm:p-10">
			<h1 class="text-4xl font-bold leading-none text-center sm:text-5xl text-emerald-600 hover:text-emerald-700">Our team</h1>
			
			<p class="max-w-2xl text-center dark:text-gray-700">At a assumenda quas cum earum ut itaque commodi saepe rem aspernatur quam natus quis nihil quod, hic explicabo doloribus magnam neque, exercitationem eius sunt!</p>
			<div class="flex flex-row flex-wrap-reverse justify-center">
				<div class="flex flex-col justify-center m-8 text-center">
					<img alt="" class="self-center flex-shrink-0 w-24 h-24 mb-4 bg-center bg-cover rounded-full dark:bg-gray-900" src="https://source.unsplash.com/100x100/?portrait?0">
					<p class="text-xl font-semibold leading-tight">Selmin Lekovic</p>
					<p class="dark:text-gray-700">Visual Designer</p>
				</div>
				<div class="flex flex-col justify-center m-8 text-center">
					<img alt="" class="self-center flex-shrink-0 w-24 h-24 mb-4 bg-center bg-cover rounded-full dark:bg-gray-900" src="https://source.unsplash.com/100x100/?portrait?1">
					<p class="text-xl font-semibold leading-tight">Dion Osmani</p>
					<p class="dark:text-gray-700">Visual Designer</p>
				</div>
				<div class="flex flex-col justify-center m-8 text-center">
					<img alt="" class="self-center flex-shrink-0 w-24 h-24 mb-4 bg-center bg-cover rounded-full dark:bg-gray-900" src="https://source.unsplash.com/100x100/?portrait?2">
					<p class="text-xl font-semibold leading-tight">Florian Berisha</p>
					<p class="dark:text-gray-700">Visual Designer</p>
				</div>
			</div>
		</div>
	</section>
      <template #footer></template>
    </NuxtLayout>
  </div>
</template>

<script>
export default {
  head() {
    return {
      layout: false,
    }
  },

}
</script>