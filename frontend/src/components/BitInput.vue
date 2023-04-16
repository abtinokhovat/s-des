<script setup lang="ts">
const bit = ref(0);
const emit = defineEmits(["onChange"]);
const props = defineProps({
  index: Number,
});

function change() {
  bit.value = bit.value ? 0 : 1;
  emit("onChange", { bit: bit.value, index: props.index });
}
</script>

<template>
  <div
    class="cursor-pointer px-1 bg-red-400 bg-opacity-40 ml-1 rounded-md border-2 border-red-400 min-w-[30px] hover:bg-opacity-30 hover:border-opacity-30"
    @click="change"
  >
    {{ bit }}
  </div>
</template>

<style scoped></style>
