<script setup lang="ts">
import BinaryElement from "~/components/BinaryElement.vue";

const props = defineProps({
  binaryArray: {
    type: String,
    required: true,
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
    />
  </div>
</template>
