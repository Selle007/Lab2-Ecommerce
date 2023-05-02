

export default defineNuxtConfig({
 
  css: ['~/assets/css/main.css'],
  postcss: {
    plugins: {
      tailwindcss: {},
      autoprefixer: {},
    },
  },
  head: {
    script: [
      { src: '~/assets/main.js', type: 'text/javascript', body: true }
    ]
  }
  
})
