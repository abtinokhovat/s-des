<script setup lang="ts">
import BitInput from "~/components/BitInput.vue";

const emit = defineEmits(["onChange"]);
const props = defineProps({
  length: {
    type: Number,
    default() {
      return 10;
    },
  },
});

const bitArrayString = ref("0".repeat(props.length));

function onChange({ bit, index }: { bit: 0 | 1; index: number }) {
  bitArrayString.value = replaceCharAtIndex(
    bitArrayString.value,
    index - 1,
    bit.toString()
  );
  emit("onChange", bitArrayString.value);
}

function replaceCharAtIndex(
  str: string,
  index: number,
  newChar: string
): string {
  const strArray = str.split("");
  strArray[index] = newChar;
  return strArray.join("");
}
</script>

<template>
  <div>
    <div class="flex">
      <bit-input
        @on-change="onChange"
        v-for="index in length"
        :index="index"
        :key="index"
      />
    </div>
  </div>
</template>
