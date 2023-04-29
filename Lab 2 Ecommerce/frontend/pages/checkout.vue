<template>
    <div>
        <NuxtLayout name="client">
            <template #header></template>
            <section>
                <h1 class="sr-only">Checkout</h1>

                <div class="mx-auto grid max-w-screen-2xl grid-cols-1 md:grid-cols-2">
                    <div class="bg-gray-50 py-12 md:py-24">
                        <div class="mx-auto max-w-lg space-y-8 px-4 lg:px-8">
                            <div class="flex items-center gap-4">
                                <span class="h-10 w-10 rounded-full bg-emerald-700"></span>

                                <img class="h-12" viewBox="0 0 28 24" fill="none" src="../assets/images/logo.png" />
                            </div>

                            <div>
                                <p class="text-4xl font-medium tracking-tight text-gray-900">
                                    Your total is: 15&euro;
                                </p>


                            </div>

                            <div>
                                <div class="flow-root">
                                    <ul class="-my-4 divide-y divide-gray-100">
                                    <!-- V-for goes in li tag -->
                                        <li >
                                            <a href="/"
                                                class="flex items-center gap-4  border rounded-lg shadow-md w-full my-6 px-4 pt-2">
                                                <img src="../assets/images/2.png" alt=""
                                                    class="h-16 w-16 rounded object-cover" />


                                                <div>
                                                    <h3 class="text-2xl text-gray-900">TEST ITEM
                                                    </h3>

                                                    <dl class="mt-0.5 space-y-px text-[10px] text-gray-600">
                                                        <div>
                                                            <dt class="inline text-sm">Description: </dt>
                                                            <dd class="inline text-sm"> 1asdawdasdasdasdsadsad
                                                            </dd>
                                                        </div>

                                                        <div>
                                                            <dt class="inline text-sm">Quanitity: </dt>
                                                            <dd class="inline text-sm"> 2</dd>
                                                        </div>

                                                        <div>
                                                            <dt class="inline text-sm">Price: </dt>
                                                            <dd class="inline text-sm"> 123&euro;
                                                            </dd>
                                                        </div>
                                                    </dl>
                                                </div>
                                            </a>
                                        </li>
                                        <!--DELETE LATER DOWN-->
                                        <li >
                                            <a href="/"
                                                class="flex items-center gap-4  border rounded-lg shadow-md w-full my-6 px-4 pt-2">
                                                <img src="../assets/images/2.png" alt=""
                                                    class="h-16 w-16 rounded object-cover" />


                                                <div>
                                                    <h3 class="text-2xl text-gray-900">TEST ITEM
                                                    </h3>

                                                    <dl class="mt-0.5 space-y-px text-[10px] text-gray-600">
                                                        <div>
                                                            <dt class="inline text-sm">Description: </dt>
                                                            <dd class="inline text-sm"> 1asdawdasdasdasdsadsad
                                                            </dd>
                                                        </div>

                                                        <div>
                                                            <dt class="inline text-sm">Quanitity: </dt>
                                                            <dd class="inline text-sm"> 2</dd>
                                                        </div>

                                                        <div>
                                                            <dt class="inline text-sm">Price: </dt>
                                                            <dd class="inline text-sm"> 123&euro;
                                                            </dd>
                                                        </div>
                                                    </dl>
                                                </div>
                                            </a>
                                        </li>
                                        
                                        <li >
                                            <a href="/"
                                                class="flex items-center gap-4  border rounded-lg shadow-md w-full my-6 px-4 pt-2">
                                                <img src="../assets/images/2.png" alt=""
                                                    class="h-16 w-16 rounded object-cover" />


                                                <div>
                                                    <h3 class="text-2xl text-gray-900">TEST ITEM
                                                    </h3>

                                                    <dl class="mt-0.5 space-y-px text-[10px] text-gray-600">
                                                        <div>
                                                            <dt class="inline text-sm">Description: </dt>
                                                            <dd class="inline text-sm"> 1asdawdasdasdasdsadsad
                                                            </dd>
                                                        </div>

                                                        <div>
                                                            <dt class="inline text-sm">Quanitity: </dt>
                                                            <dd class="inline text-sm"> 2</dd>
                                                        </div>

                                                        <div>
                                                            <dt class="inline text-sm">Price: </dt>
                                                            <dd class="inline text-sm"> 123&euro;
                                                            </dd>
                                                        </div>
                                                    </dl>
                                                </div>
                                            </a>
                                        </li>
                                        <!--DELETE LATER ^-->
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="bg-white py-12 md:py-24">
                        <div class="mx-auto max-w-lg px-4 lg:px-8">
                            <form class="grid grid-cols-6 gap-4" action="#">
                                <div class="col-span-3">
                                    <label for="name" class="block text-xs font-medium text-gray-700">
                                        First Name
                                    </label>

                                    <input type="text" id="name" placeholder="Name"
                                        class="mt-1 h-12 px-2 w-full rounded-md border shadow-md sm:text-sm"
                                        required />
                                </div>

                                <div class="col-span-3">
                                    <label for="surname" class="block text-xs font-medium text-gray-700">
                                        Last Name
                                    </label>

                                    <input type="text" id="surname" placeholder="Surname"
                                        class="mt-1 h-12 px-2 w-full rounded-md border shadow-md sm:text-sm"
                                        required />
                                </div>

                                <div class="col-span-6">
                                    <label for="email" class="block text-xs font-medium text-gray-700">
                                        Email
                                    </label>

                                    <input type="email" id="email" placeholder="Email"
                                        class="mt-1 h-12 px-2 w-full rounded-md border shadow-md sm:text-sm"
                                         required />
                                </div>

                                <div class="col-span-6">
                                    <label for="phone" class="block text-xs font-medium text-gray-700">
                                        Phone
                                    </label>

                                    <input type="tel" id="phone" placeholder="Phone"
                                        class="mt-1 h-12 px-2 w-full rounded-md border shadow-md sm:text-sm"
                                        required />
                                </div>


                                <fieldset class="col-span-6">
                                    <legend class="block text-sm font-medium text-gray-700">
                                        Billing Address
                                    </legend>


                                    <div>
                                        <label class="sr-only" for="country"> Country </label>

                                        <input type="text" id="country" placeholder="Country"
                                            class="mt-1 h-12 px-4 w-full rounded-md border shadow-md sm:text-sm"
                                             required />
                                    </div>

                                    <div>
                                        <label class="sr-only" for="city"> City </label>

                                        <input type="text" id="city" placeholder="City"
                                            class="mt-3 h-12 px-4 w-full rounded-md border shadow-md sm:text-sm"
                                             required />
                                    </div>
                                    <div>
                                        <label class="sr-only" for="address"> Address </label>

                                        <input type="text" id="address" placeholder="Address"
                                            class="mt-3 h-12 px-4 w-full rounded-md border shadow-md sm:text-sm"
                                            required />
                                    </div>
                                    <div>
                                        <label class="sr-only" for="zipCode"> ZipCode </label>

                                        <input type="text" id="zipCode" placeholder="ZipCode"
                                            class="mt-3 h-12 px-4 w-full rounded-md border shadow-md sm:text-sm"
                                            required />
                                    </div>

                                </fieldset>

                                <div class="col-span-6">
                                    <button
                                        class="block w-full rounded-md bg-emerald-700 hover:bg-emerald-800 p-2.5 text-sm text-white transition hover:shadow-lg">
                                        Pay Now
                                    </button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </section>
            <template #footer></template>
        </NuxtLayout>
    </div>
</template>

<script setup>
definePageMeta({
    layout: false,
});
</script>