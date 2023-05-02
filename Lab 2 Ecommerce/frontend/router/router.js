import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/',
      component: () => import('@/pages/index.vue')
    },
    {
      path: '/about',
      component: () => import('@/pages/about.vue')
    },
    {
      path: '/contact',
      component: () => import('@/pages/contact.vue')
    },
    {
      path: '/register',
      component: () => import('@/pages/register.vue')
    },
    {
      path: '/login',
      component: () => import('@/pages/login.vue')
    },
    {
      path: '/cart',
      component: () => import('@/pages/cart.vue')
    },
    {
      path: '/checkout',
      component: () => import('@/pages/checkout.vue')
    },
    {
      path: '/products',
      component: () => import('@/pages/products.vue')
    },
    {
      path: '/product',
      component: () => import('@/pages/product.vue')
    },
    {
      path: '/dashboard/product/create-product',
      component: () => import('@/pages/dashboard/product/create-product.vue')
    },
    
    // add more routes here
  ]
})

export default router
