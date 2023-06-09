import axios from 'axios'
import Cookies from 'js-cookie'


const api = axios.create({
    baseURL: 'https://localhost:7299', // Replace with your API's base URL
})

export default {
    // Products
    async getProducts() {
        let token = Cookies.get('token');
        return api.get('/api/products', { headers: { Authorization: `Bearer ${token}` } })
    },
    async getProductsById(id) {
        let token = Cookies.get('token');
        return api.get(`/api/products/${id}`, { headers: { Authorization: `Bearer ${token}` } })
    },
    async createProduct(formData) {
        let token = Cookies.get('token');
        console.log(formData)
        return api.post('/api/products', formData, { headers: { Authorization: `Bearer ${token}`, 'Content-Type': 'multipart/form-data' } })
    },
    async searchProducts(query) {
        let token = Cookies.get('token');
        return api.get(`/api/products/search?query=${query}`, { headers: { Authorization: `Bearer ${token}` } });
    },
    async updateProduct(id, product) {
        let token = Cookies.get('token');
        return api.put(`/api/products/${id}`, product, { headers: { Authorization: `Bearer ${token}` } })
    },
    async deleteProduct(id) {
        let token = Cookies.get('token');
        return api.delete(`/api/products/${id}`, { headers: { Authorization: `Bearer ${token}` } })
    },

    // User Management
    async register(user) {
        return api.post('/api/account/register', user)
    },
    async login(user) {


        return api.post('/api/account/login', user)
    },
    async logout() {
        Cookies.remove('token');
        return api.post('/api/account/logout')
    },
    async makeAdmin(userId) {
        let token = Cookies.get('token');
        return api.post(`/api/account/makeAdmin/${userId}`, null, { headers: { Authorization: `Bearer ${token}` } })
    },
    async updateProfile(userId, updatedData) {
        let token = Cookies.get('token');
        return api.put(`/api/account/profile/${userId}`, updatedData, { headers: { Authorization: `Bearer ${token}` } });
    },
    async getUsers() {
        let token = Cookies.get('token');
        return api.get('/api/account/users', { headers: { Authorization: `Bearer ${token}` } });
    },
    async updateUserRole(userId) {
        let token = Cookies.get('token');
        return api.put(`/api/account/userRole/${userId}`, { headers: { Authorization: `Bearer ${token}` } });
    },
    async getProfile() {
        let token = Cookies.get('token');
        return api.get('/api/account/profile', { headers: { Authorization: `Bearer ${token}` } });
    },
    async deleteUser(userId) {
        const token = Cookies.get('token');
        return api.delete(`/api/account/users/${userId}`, { headers: { Authorization: `Bearer ${token}` } });
    },



    // Categories
    async getCategories() {
        let token = Cookies.get('token');
        return api.get('/api/categories', { headers: { Authorization: `Bearer ${token}` } })
    },
    async getCategoryById(id) {
        let token = Cookies.get('token');
        return api.get(`/api/categories/${id}`, { headers: { Authorization: `Bearer ${token}` } })
    },
    async createCategory(category) {
        let token = Cookies.get('token');
        return api.post('/api/categories', category, { headers: { Authorization: `Bearer ${token}` } })
    },
    async updateCategory(id, category) {
        let token = Cookies.get('token');
        return api.put(`/api/categories/${id}`, category, { headers: { Authorization: `Bearer ${token}` } })
    },
    async deleteCategory(id) {
        let token = Cookies.get('token');
        return api.delete(`/api/categories/${id}`, { headers: { Authorization: `Bearer ${token}` } })
    },

    // Contacts
    async getContacts() {
        let token = Cookies.get('token');
        return api.get('/api/contacts', { headers: { Authorization: `Bearer ${token}` } });
    },
    async getContactById(id) {
        let token = Cookies.get('token');
        return api.get(`/api/contacts/${id}`, { headers: { Authorization: `Bearer ${token}` } });
    },
    async createContact(contact) {
        let token = Cookies.get('token');
        return api.post('/api/contacts', contact, { headers: { Authorization: `Bearer ${token}` } });
    },
    async updateContact(id, contact) {
        let token = Cookies.get('token');
        return api.put(`/api/contacts/${id}`, contact, { headers: { Authorization: `Bearer ${token}` } });
    },
    async deleteContact(id) {
        let token = Cookies.get('token');
        return api.delete(`/api/contacts/${id}`, { headers: { Authorization: `Bearer ${token}` } });
    },


    // Get cart items
    async getCart() {
        const token = Cookies.get('token');
        return api.get('/api/cart/items', { headers: { Authorization: `Bearer ${token}` } });
    },
    // Add item to cart
    async addToCart(cartItem) {
        const token = Cookies.get('token');
        return api.post('/api/cart/items', cartItem, { headers: { Authorization: `Bearer ${token}` } });
    },
    // Remove item from cart
    async removeFromCart(productId) {
        const token = Cookies.get('token');
        return api.delete(`/api/cart/items/${productId}`, { headers: { Authorization: `Bearer ${token}` } });
    },
    // Update item quantity in cart
    async updateCartItemQuantity(productId, quantity) {
        const token = Cookies.get('token');
        return api.put(`/api/cart/items/${productId}`, { ProductId: productId, Quantity: quantity }, { headers: { Authorization: `Bearer ${token}` } });
    },
    // Clear cart
    async clearCart() {
        const token = Cookies.get('token');
        return api.delete('/api/cart', { headers: { Authorization: `Bearer ${token}` } });
    },
    // Orders
    async getOrders() {
        const token = Cookies.get('token');
        return api.get('/api/order', { headers: { Authorization: `Bearer ${token}` } });
    },

    async getUserOrders() {
        const token = Cookies.get('token');
        return api.get('/api/order/userOrders', { headers: { Authorization: `Bearer ${token}` } });
    },

    async getOrderById(orderId) {
        const token = Cookies.get('token');
        return api.get(`/api/order/${orderId}`, { headers: { Authorization: `Bearer ${token}` } });
    },

    async createOrder(shippingDetails) {
        const token = Cookies.get('token');
        return api.post('/api/order', shippingDetails, { headers: { Authorization: `Bearer ${token}` } });
    },

    async updateOrderStatus(orderId, status) {
        const token = Cookies.get('token');
        return api.put(`/api/order/${orderId}`, { Status: status }, { headers: { Authorization: `Bearer ${token}` } });
    },


    // Stripe
    async addStripeCustomer(customer) {
        const token = Cookies.get('token');
        return api.post('/api/stripe/customer/add', customer);
    },

    async addStripePayment(payment) {
        const token = Cookies.get('token');
        return api.post('/api/stripe/payment/add', payment);
    },

    // Reviews
    async createReview(formData) {
        const token = Cookies.get('token');
        return api.post(`/api/products/reviews`, formData, { headers: { Authorization: `Bearer ${token}` } });
    },

    async getProductReviews(productId) {
        const token = Cookies.get('token');
        return api.get(`/api/products/reviews/${productId}`, { headers: { Authorization: `Bearer ${token}` } });
    },

    async getTopProductReviews(productId) {
        const token = Cookies.get('token');
        return api.get(`/api/products/${productId}`, { headers: { Authorization: `Bearer ${token}` } });
    },

    // Get cart items
    async getWishlist() {
        const token = Cookies.get('token');
        return api.get('/api/cart/items', { headers: { Authorization: `Bearer ${token}` } });
    },
    // Add item to cart
    async addToWishlist(cartItem) {
        const token = Cookies.get('token');
        return api.post('/api/cart/items', cartItem, { headers: { Authorization: `Bearer ${token}` } });
    },
    // Remove item from cart
    async removeFromWishlist(productId) {
        const token = Cookies.get('token');
        return api.delete(`/api/cart/items/${productId}`, { headers: { Authorization: `Bearer ${token}` } });
    },


}
