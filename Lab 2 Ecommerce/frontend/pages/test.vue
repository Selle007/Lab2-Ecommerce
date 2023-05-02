<template>
    <div>
        <NuxtLayout name="client">
            <template #header></template>
            <template #footer></template>
        </NuxtLayout>
    </div>
</template>

<script>
export default {
    head() {
        return {
            layout: false,
        }
    },
}
</script>