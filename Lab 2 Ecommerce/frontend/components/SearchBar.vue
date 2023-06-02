<template>
    <div class="relative">
      <button @click="toggleSearch" class="absolute right-0 top-0">
        <svg v-if="!isSearchOpen" class="-mt-2 mr-2 w-5 h-5 text-gray-500" viewBox="0 0 24 24" fill="none" stroke="currentColor"
          stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
          <circle cx="11" cy="11" r="8"></circle>
          <line x1="21" y1="21" x2="16.65" y2="16.65"></line>
        </svg>
        <svg v-else class="mt-1 mr-4 w-5 h-5 text-gray-500" viewBox="0 0 24 24" fill="none" stroke="currentColor"
          stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
          <circle cx="11" cy="11" r="8"></circle>
          <line x1="21" y1="21" x2="16.65" y2="16.65"></line>

        </svg>
      </button>
  
      <transition name="slide">
        <input v-if="isSearchOpen" v-model="searchQuery" type="text" placeholder="Search products"
          class="px-4 py-2 mr-2 h-8 text-sm rounded-xl focus:outline-none focus:bg-white focus:ring-1 focus:ring-emerald-500"
          @keydown.enter="submitSearch" />
      </transition>
  
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        isSearchOpen: false,
        searchQuery: '',
      };
    },
    methods: {
      toggleSearch() {
        this.isSearchOpen = !this.isSearchOpen;
        if (this.isSearchOpen) {
          this.$nextTick(() => {
            this.$refs.searchInput.focus();
          });
        }
      },
      submitSearch() {
        if (this.searchQuery.trim() !== '') {
          this.$emit('search', this.searchQuery);
          this.searchQuery = '';
          this.isSearchOpen = false;
        }
      },
    },
  };
  </script>
  
  <style scoped>
  .slide-enter-active,
  .slide-leave-active {
    transition: all 0.3s ease;
  }
  
  .slide-enter,
  .slide-leave-to {
    opacity: 0;
    transform: translateX(-20px);
  }
  </style>
  