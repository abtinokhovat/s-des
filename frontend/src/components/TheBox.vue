<script setup lang="ts">
const props = defineProps<{
  title:string
  binary:string
}>();

</script>

<template>
  <div class="flex flex-col items-center">
    <div class="flex justify-center items-center flex-col px-3 py-3 border-2 border-sky-500 rounded-2xl bg-sky-500 bg-opacity-50">
      <div class="text-gray-400">
        {{ title }}
      </div>
      <div>
        {{ binary }}
      </div>
    </div>
    <div class="text-xl">
      &#8595;
    </div>
  </div>
</template>
