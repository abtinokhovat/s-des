<script setup lang="ts">
import { useDataStore } from "~/stores/data";
import { storeToRefs } from "pinia";

const store = useDataStore();
const { update, setPlain } = store;
const { plain } = storeToRefs(store);

const props = defineProps({
  data: {
    type: Object,
    required: true,
  },
});

const plainData = ref("10101010");

watch(plainData, (newPlain, oldPlain) => {
  if (newPlain.length >= 9) plainData.value = oldPlain;
  setPlain(plainData.value);
});

onMounted(() => {
  if (plain) plainData.value = plain.value;
});
</script>

<template>
  <div class="flex flex-col items-center">
    <div
      class="flex justify-center items-center flex-col px-1 py-1 border-2 border-sky-500 rounded-2xl bg-sky-500 bg-opacity-50"
    >
      <div class="text-yellow-400 text-sm">Plain Text</div>
      <div>
        <input
          style="letter-spacing: 5px"
          v-model="plainData"
          class="w-30 text-center bg-transparent !outline-none"
        />
      </div>
    </div>
  </div>
</template>
