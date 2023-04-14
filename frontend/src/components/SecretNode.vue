<script setup lang="ts">
import { useDataStore } from "~/stores/data";
import { storeToRefs } from "pinia";

const store = useDataStore();
const { update, setSecret } = store;
const { secret } = storeToRefs(store);

const props = defineProps({
  data: {
    type: Object,
    required: true,
  },
});

const secretData = ref("1010101010");

watch(secretData, (newPlain, oldPlain) => {
  if (newPlain.length >= 11) secretData.value = oldPlain;
  setSecret(secretData.value);
});

onMounted(() => {
  if (secret.value.length === 10) secretData.value = secret.value;
});
</script>

<template>
  <div class="flex flex-col items-center">
    <div
      class="flex justify-center items-center flex-col px-1 py-1 border-2 border-sky-500 rounded-2xl bg-sky-500 bg-opacity-50"
    >
      <div class="text-yellow-400 text-sm">Secret</div>
      <div>
        <input
          style="letter-spacing: 5px"
          v-model="secretData"
          class="w-35 text-center bg-transparent !outline-none"
        />
      </div>
    </div>
  </div>
</template>
