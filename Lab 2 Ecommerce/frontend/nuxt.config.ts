

export default defineNuxtConfig({
  router: {
    middleware: [],
    extendRoutes(routes, resolve) {
      // remove default routes created by Nuxt
      routes.splice(0)

      // add routes defined in router.js
      router.options.routes.forEach(route => {
        routes.push(route)
      })
    }
  },
  css: ['~/assets/css/main.css'],
  postcss: {
    plugins: {
      tailwindcss: {},
      autoprefixer: {},
    },
  },
  
})
