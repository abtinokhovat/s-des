<script setup lang="ts">
useHead({
  title: 'Abtin Okhovat - S-DES',
  meta: [
    { name: 'description', content: 'S-DES Demonstration' },
    {
      name: 'theme-color',
      content: computed(() => isDark.value ? '#00aba9' : '#ffffff'),
    },
  ],
  link: [
    {
      rel: 'icon',
      type: 'image/svg+xml',
      href: computed(() => preferredDark.value ? '/favicon-dark.svg' : '/favicon.svg'),
    },
  ],
})
</script>

<template>
  <RouterView />
</template>
