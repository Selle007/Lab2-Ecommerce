import axios from 'axios'

const api = axios.create({
    baseURL: 'https://localhost:7299', // Replace with your API's base URL
})

export default {
    // Products
    async getProducts() {
        let token = localStorage.getItem('token');
        return api.get('/api/products', { headers: { Authorization: `Bearer ${token}` } })
    },
    async getProductsById(id) {
        let token = localStorage.getItem('token');
        return api.get(`/api/products/${id}`, { headers: { Authorization: `Bearer ${token}` } })
    },
    async createProduct(product) {
        let token = localStorage.getItem('token');
        return api.post('/api/products', product, { headers: { Authorization: `Bearer ${token}` } })
    },
    async updateProduct(id, product) {
        let token = localStorage.getItem('token');
        return api.put(`/api/products/${id}`, product, { headers: { Authorization: `Bearer ${token}` } })
    },
    async deleteProduct(id) {
        let token = localStorage.getItem('token');
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
        localStorage.removeItem('token')
        return api.post('/api/account/logout')
    },
    async makeAdmin(userId) {
        let token = localStorage.getItem('token');
        return api.post(`/api/account/makeAdmin/${userId}`, null, { headers: { Authorization: `Bearer ${token}` } })
    },

    // Categories
    async getCategories() {
        let token = localStorage.getItem('token');
        return api.get('/api/categories', { headers: { Authorization: `Bearer ${token}` } })
    },
    async getCategoryById(id) {
        let token = localStorage.getItem('token');
        return api.get(`/api/categories/${id}`, { headers: { Authorization: `Bearer ${token}` } })
    },
    async createCategory(category) {
        let token = localStorage.getItem('token');
        return api.post('/api/categories', category, { headers: { Authorization: `Bearer ${token}` } })
    },
    async updateCategory(id, category) {
        let token = localStorage.getItem('token');
        return api.put(`/api/categories/${id}`, category, { headers: { Authorization: `Bearer ${token}` } })
    },
    async deleteCategory(id) {
        let token = localStorage.getItem('token');
        return api.delete(`/api/categories/${id}`, { headers: { Authorization: `Bearer ${token}` } })
    },

    // Contacts
    async getContacts() {
        let token = localStorage.getItem('token');
        return api.get('/api/contacts', { headers: { Authorization: `Bearer ${token}` } });
    },
    async getContactById(id) {
        let token = localStorage.getItem('token');
        return api.get(`/api/contacts/${id}`, { headers: { Authorization: `Bearer ${token}` } });
    },
    async createContact(contact) {
        let token = localStorage.getItem('token');
        return api.post('/api/contacts', contact, { headers: { Authorization: `Bearer ${token}` } });
    },
    async updateContact(id, contact) {
        let token = localStorage.getItem('token');
        return api.put(`/api/contacts/${id}`, contact, { headers: { Authorization: `Bearer ${token}` } });
    },
    async deleteContact(id) {
        let token = localStorage.getItem('token');
        return api.delete(`/api/contacts/${id}`, { headers: { Authorization: `Bearer ${token}` } });
    },


    // Get cart items
    async getCart() {
        const token = localStorage.getItem('token');
        return api.get('/api/cart/items', { headers: { Authorization: `Bearer ${token}` } });
    },

    // Add item to cart
    async addToCart(cartItem) {
        const token = localStorage.getItem('token');
        return api.post('/api/cart/items', cartItem, { headers: { Authorization: `Bearer ${token}` } });
      },
      

    // Remove item from cart
    async removeFromCart(productId) {
        const token = localStorage.getItem('token');
        return api.delete(`/api/cart/items/${productId}`, { headers: { Authorization: `Bearer ${token}` } });
    },

    // Update item quantity in cart
    async updateCartItemQuantity(productId, quantity) {
        const token = localStorage.getItem('token');
        return api.put(`/api/cart/items/${productId}`, { ProductId: productId, Quantity: quantity }, { headers: { Authorization: `Bearer ${token}` } });
    },

    // Clear cart
    async clearCart() {
        const token = localStorage.getItem('token');
        return api.delete('/api/cart', { headers: { Authorization: `Bearer ${token}` } });
    },


}
