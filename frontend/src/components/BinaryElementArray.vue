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
    required: true,
  },
});

const splitBinaryArray = computed(() => props.binaryArray?.split("-"));
</script>

<template>
  <div class="flex">
    <binary-element
      class="mr-2"
      v-for="binaryElement in splitBinaryArray"
      :binary="binaryElement"
      :secret="secret"
      :type="type"
    />
  </div>
</template>
