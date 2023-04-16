<script setup lang="ts">
import BinaryElement from "~/components/BinaryElement.vue";

const props = defineProps({
  binaryArray: {
    type: String,
    required: true,
  },
  type: {
    type: String,
    validator(value: string) {
      return ["cipher", "plain"].includes(value);
    },
    default() {
      return "plain";
    },
  },
  secret: {
    type: String,
  },
});

const splitBinaryArray = computed(() => props.binaryArray?.split("-"));
</script>

<template>
  <div
    class="grid lg:grid-cols-3 md:grid-cols-2 grid-cols-3 gap-1 max-h-[60px] lg:max-h-[150px] overflow-y-scroll"
  >
    <binary-element
      v-for="binaryElement in splitBinaryArray"
      :binary="binaryElement"
      :secret="secret"
      :type="type"
    />
  </div>
</template>
