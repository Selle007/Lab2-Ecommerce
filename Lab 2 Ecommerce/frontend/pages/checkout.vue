<template>
    <div>
        <NuxtLayout name="client">
            <template #header></template>
            <section>
                <h1 class="sr-only">Checkout</h1>

                <div class="mx-auto grid max-w-screen-2xl grid-cols-1 md:grid-cols-2">
                    <div class="py-12 md:py-24">
                        <div class="mx-auto max-w-lg space-y-8 px-4 lg:px-8">
                            <div class="flex items-center gap-4">
                                <span class="h-10 w-10 rounded-full bg-emerald-700"></span>

                                <img class="h-12" viewBox="0 0 28 24" fill="none" src="../assets/images/logo.png" />
                            </div>

                            <div>
                                <p class="text-4xl font-medium tracking-tight text-gray-900">
                                    Your total is: {{ cartTotal }}&euro;
                                </p>


                            </div>

                            <div>
                                <div class="flow-root">
                                    <ul class="-my-4 divide-y divide-gray-100">
                                        <!-- V-for goes in li tag -->
                                        <li v-for="item in cartItems" :key="item.id">
                                            <a :href="`/products/${item.productId}`"
                                                class="flex items-center gap-4  border rounded-lg shadow-md w-full my-6 px-4 pt-2 pb-2">
                                                <img :src=getProductImage(item.productId) alt=""
                                                    class="h-24 w-24 rounded object-cover" />
                                                <div>
                                                    <h3 class="text-2xl text-gray-900">{{ getProductName(item.productId) }}
                                                    </h3>
                                                    <dl class="mt-0.5 space-y-px text-[10px] text-gray-600">
                                                        <div>
                                                            <dt class="inline text-sm">Description: </dt>
                                                            <dd class="inline text-sm"> {{ getProductDesc(item.productId) }}
                                                            </dd>
                                                        </div>
                                                        <div>
                                                            <dt class="inline text-sm">Quanitity: </dt>
                                                            <dd class="inline text-sm"> {{
                                                                getProductQuanitity(item.productId) }}</dd>
                                                        </div>
                                                        <div>
                                                            <dt class="inline text-sm">Price: </dt>
                                                            <dd class="inline text-sm"> {{ item.price }}&euro;
                                                            </dd>
                                                        </div>
                                                    </dl>
                                                </div>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="bg-white py-12 md:py-24">
                        <div class="mx-auto max-w-lg px-4 lg:px-8">
                            <form class="grid grid-cols-6 gap-4" @submit.prevent="placeOrder">
                                <div class="col-span-3">
                                    <label for="name" class="block text-xs font-medium text-gray-700">
                                        First Name
                                    </label>
                                    <input type="text" id="name" placeholder="Name" v-model="shippingDetails.name"
                                        class="mt-1 h-12 px-2 w-full rounded-md border shadow-md sm:text-sm" />
                                </div>
                                <div class="col-span-3">
                                    <label for="surname" class="block text-xs font-medium text-gray-700">
                                        Last Name
                                    </label>
                                    <input type="text" id="surname" placeholder="Surname" v-model="shippingDetails.surname"
                                        class="mt-1 h-12 px-2 w-full rounded-md border shadow-md sm:text-sm" />
                                </div>
                                <div class="col-span-6">
                                    <label for="email" class="block text-xs font-medium text-gray-700">
                                        Email
                                    </label>
                                    <input type="email" id="email" placeholder="Email" v-model="shippingDetails.email"
                                        class="mt-1 h-12 px-2 w-full rounded-md border shadow-md sm:text-sm" />
                                </div>
                                <div class="col-span-6">
                                    <label for="phone" class="block text-xs font-medium text-gray-700">
                                        Phone
                                    </label>
                                    <input type="tel" id="phone" placeholder="Phone" v-model="shippingDetails.phone"
                                        class="mt-1 h-12 px-2 w-full rounded-md border shadow-md sm:text-sm" />
                                </div>
                                <fieldset class="col-span-6">
                                    <legend class="block text-sm font-medium text-gray-700">
                                        Billing Address
                                    </legend>
                                    <div>
                                        <label class="sr-only" for="country"> Country </label>
                                        <input type="text" id="country" placeholder="Country"
                                            v-model="shippingDetails.country"
                                            class="mt-1 h-12 px-4 w-full rounded-md border shadow-md sm:text-sm" />
                                    </div>

                                    <div>
                                        <label class="sr-only" for="city"> City </label>
                                        <input type="text" id="city" placeholder="City" v-model="shippingDetails.city"
                                            class="mt-3 h-12 px-4 w-full rounded-md border shadow-md sm:text-sm" />
                                    </div>
                                    <div>
                                        <label class="sr-only" for="address"> Address </label>
                                        <input type="text" id="address" placeholder="Address"
                                            v-model="shippingDetails.address"
                                            class="mt-3 h-12 px-4 w-full rounded-md border shadow-md sm:text-sm" />
                                    </div>
                                    <div>
                                        <label class="sr-only" for="zipCode"> ZipCode </label>
                                        <input type="text" id="zipCode" placeholder="ZipCode"
                                            v-model="shippingDetails.zipCode"
                                            class="mt-3 h-12 px-4 w-full rounded-md border shadow-md sm:text-sm" />
                                    </div>
                                </fieldset>

                                <!-- Card details form fields (using Stripe Elements) -->
                                <fieldset class="col-span-6">
                                    <legend class="block text-sm font-medium text-gray-700">
                                        Card Details
                                    </legend>

                                    <div class="mt-1 -space-y-px rounded-md bg-white shadow-sm">
                                        <div>
                                            <label for="cardHolderName" class="sr-only"> Card Holder Name </label>

                                            <input type="text" id="cardHolderName" placeholder="Card Holder Name"
                                                class="relative mt-1 w-full rounded-t-md border shadow-md focus:z-10 sm:text-sm"
                                                v-model="customer.name" />
                                        </div>
                                        <div>
                                            <label for="CardNumber" class="sr-only"> Card Number </label>

                                            <input type="text" id="CardNumber" placeholder="Card Number"
                                                class="relative w-full border shadow-md focus:z-10 sm:text-sm"
                                                v-model="customer.creditCard.cardNumber" />
                                        </div>

                                        <div class="flex">
                                            <div class="flex-1">
                                                <label for="CardExpiry" class="sr-only"> Card Expiry </label>

                                                <input type="text" id="CardExpiry" placeholder="Expiry Date"
                                                    class="relative w-full rounded-es-md border shadow-md focus:z-10 sm:text-sm"
                                                    v-model="customer.creditCard.expirationMonth" />
                                            </div>
                                            <div class="flex-1">
                                                <label for="CardExpiry" class="sr-only"> Card Expiry </label>

                                                <input type="text" id="CardExpiry" placeholder="Expiry Date"
                                                    class="relative w-full  shadow-md focus:z-10 sm:text-sm"
                                                    v-model="customer.creditCard.expirationYear" />
                                            </div>

                                            <div class="-ms-px flex-1">
                                                <label for="CardCVC" class="sr-only"> Card CVC </label>

                                                <input type="text" id="CardCVC" placeholder="CVC"
                                                    class="relative w-full rounded-ee-md border shadow-md focus:z-10 sm:text-sm"
                                                    v-model="customer.creditCard.cvc" />
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>

                                <div class="col-span-6">
                                    <button type="submit"
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
            cartItems: [],
            Products: [],
            shippingDetails: {
                name: '',
                surname: '',
                city: '',
                address: '',
                country: '',
                phone: '',
                email: '',
                zipCode: ''
            },
            customer: {
                email: '',
                name: '',
                creditCard: {
                    name: '',
                    cardNumber: '',
                    expirationYear: '',
                    expirationMonth: '',
                    cvc: '',
                }
            }
        };
    },
    async mounted() {
        try {
            const response = await api.getCart();
            this.cartItems = response.data;
            this.loading = false;
        } catch (error) {
            console.error(error);
            this.loading = true;
        }
        try {
            const response = await api.getProducts();
            this.Products = response.data;
            this.loading = false;
        } catch (error) {
            console.error(error);
            this.loading = true;
        }
    },
    computed: {
        cartTotal() {
            return this.cartItems.reduce((total, item) => {
                const product = this.Products.find((p) => p.id === item.productId);
                if (product) {
                    return total + product.price * item.quantity;
                } else {
                    return total;
                }
            }, 0);
        },
    },
    methods: {
        async placeOrder() {
            try {
                const customerResponse = await api.addStripeCustomer({
                    email: this.shippingDetails.email,
                    name: this.customer.name,
                    creditCard: {
                        name: this.customer.name,
                        cardNumber: this.customer.creditCard.cardNumber,
                        expirationYear: this.customer.creditCard.expirationYear,
                        expirationMonth: this.customer.creditCard.expirationMonth,
                        cvc: this.customer.creditCard.cvc,
                    },
                });

                if (customerResponse.status === 200) {
                    const paymentResponse = await api.addStripePayment({
                        customerId: customerResponse.data.customerId,
                        receiptEmail: this.shippingDetails.email,
                        description: "Elektronix Online Store G.O.A.T",
                        currency: "EUR",
                        amount: this.cartTotal*100,
                    });

                    if (paymentResponse.status === 200) {
                        const orderResponse = await api.createOrder({
                            Name: this.shippingDetails.name,
                            Surname: this.shippingDetails.surname,
                            City: this.shippingDetails.city,
                            Address: this.shippingDetails.address,
                            Phone: this.shippingDetails.phone,
                            Email: this.shippingDetails.email,
                            ZipCode: this.shippingDetails.zipCode,
                            Country: this.shippingDetails.country,
                        });

                        if (orderResponse.status === 200) {
                            this.cartItems = [];
                            this.$router.push(`/thankyou`);
                        } else {
                            // Handle order creation failure
                            console.error('Failed to create order:', orderResponse.error);
                            // Display an error message or take appropriate action
                        }
                    } else {
                        // Handle payment failure
                        console.error('Failed to add Stripe payment:', paymentResponse.error);
                        // Display an error message or take appropriate action
                    }
                } else {
                    // Handle customer creation failure
                    console.error('Failed to add Stripe customer:', customerResponse.error);
                    // Display an error message or take appropriate action
                }
            } catch (error) {
                // Handle any other exceptions or network errors
                console.error('An error occurred:', error);
                // Display an error message or take appropriate action
            }

        },
        getProductName(productId) {
            const product = this.Products.find((p) => p.id === productId);
            return product ? product.name : '';
        },
        getProductQuanitity(productId) {
            const product = this.Products.find((p) => p.id === productId);
            return product ? product.quantity : '';
        },
        getProductDesc(productId) {
            const product = this.Products.find((p) => p.id === productId);
            return product ? product.description : '';
        },
        getProductImage(productId) {
            const product = this.Products.find((p) => p.id === productId);
            return product ? product.image : '';
        },
    },
};
</script>
