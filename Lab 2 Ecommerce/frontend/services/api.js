import axios from 'axios'

const api = axios.create({
    baseURL: 'https://localhost:7299', // Replace with your API's base URL
})

export default {
    // Products
    async getProducts() {
        return api.get('/api/products')
    },
    async createProduct(product) {
        return api.post('/api/products', product)
    },
    async updateProduct(id, product) {
        return api.put(`/api/products/${id}`, product)
    },
    async deleteProduct(id) {
        return api.delete(`/api/products/${id}`)
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
        return api.post(`/api/account/makeAdmin/${userId}`)
    },

    // Categories
    async getCategories() {
        return api.get('/api/categories')
    },
    async createCategory(category) {
        return api.post('/api/categories', category)
    },
    async updateCategory(id, category) {
        return api.put(`/api/categories/${id}`, category)
    },
    async deleteCategory(id) {
        return api.delete(`/api/categories/${id}`)
    },
}
