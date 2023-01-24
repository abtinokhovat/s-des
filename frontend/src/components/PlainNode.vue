<script setup lang="ts">

import {useDataStore} from "~/stores/data";

const store = useDataStore()
const {update,setPlain} = store


const props = defineProps({
  data: {
    type: Object,
    required: true,
  },
})

const plain = ref('10101010')

watch(plain, (newPlain,oldPlain) => {
  if(newPlain.length >= 9)
    plain.value = oldPlain
  setPlain(plain.value)
})
</script>

<template>
  <div class="flex flex-col items-center">
    <div
        class="flex justify-center items-center flex-col px-1 py-1 border-2 border-sky-500 rounded-2xl bg-sky-500 bg-opacity-50">
      <div class="text-yellow-400 text-sm">
        Plain Text
      </div>
      <div>
        <input style="letter-spacing: 5px" v-model="plain" class="w-25 text-center bg-transparent !outline-none">
      </div>
    </div>
  </div>
</template>
