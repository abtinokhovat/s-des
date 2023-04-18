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
    class="cursor-pointer px-1 ml-1 min-w-[30px] border-2 border-dashed border-red-400 bg-red-400 bg-opacity-10 text-[#acb7c4]"
    @click="change"
  >
    {{ bit }}
  </div>
</template>

<style scoped></style>
