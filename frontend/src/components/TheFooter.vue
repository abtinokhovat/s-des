<script setup lang="ts">
const { t, availableLocales, locale } = useI18n();

// const toggleLocales = () => {
//   // change to some real logic
//   const locales = availableLocales;
//   locale.value = locales[(locales.indexOf(locale.value) + 1) % locales.length];
// };
</script>

<template>
  <nav text-xl mt-6>
    <RouterLink class="icon-btn mx-2" to="/" :title="t('button.home')">
      <div i-carbon-encryption />
    </RouterLink>
    <RouterLink
      class="icon-btn mx-2"
      to="/playground"
      :title="t('button.playground')"
    >
      <div i-carbon-play />
    </RouterLink>
    <button
      class="icon-btn mx-2 !outline-none"
      :title="t('button.toggle_dark')"
      @click="toggleDark()"
    >
      <div i="carbon-sun dark:carbon-moon" />
    </button>
    <RouterLink class="icon-btn mx-2" to="/about" :title="t('button.about')">
      <div i-carbon-dicom-overlay />
    </RouterLink>
    <a
      class="icon-btn mx-2"
      rel="noreferrer"
      href="https://github.com/abtinokhovat"
      target="_blank"
      title="GitHub"
    >
      <div i-carbon-logo-github />
    </a>
    <div class="mt-5 mx-auto text-center opacity-75 dark:opacity-50 text-sm">
      Abtin Okhovat
    </div>
  </nav>
</template>
