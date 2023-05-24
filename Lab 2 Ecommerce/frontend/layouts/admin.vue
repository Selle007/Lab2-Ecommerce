<template>
  <div class="dashboard">
    <header>
      <slot name="header">
        <Sidebar />
      </slot>
    </header>
    <main>
      <slot />
    </main>
  </div>
</template>
  


  
<style scoped>
.dashboard {
  display: flex;
}
</style>