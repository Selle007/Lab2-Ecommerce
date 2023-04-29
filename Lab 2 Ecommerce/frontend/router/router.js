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
    // add more routes here
  ]
})

export default router
