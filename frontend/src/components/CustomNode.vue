<script setup>

import {useDataStore} from "~/stores/data.ts";
import {storeToRefs} from "pinia";

const props = defineProps({
  data: {
    type: Object,
    required: true,
  },
})

const store = useDataStore()
const {flow} = storeToRefs(store)

</script>

<template>
  <div class="flex flex-col items-center">
    <div
        class="flex justify-center items-center flex-col px-1 py-1 border-2 border-sky-500 rounded-2xl bg-sky-500 bg-opacity-50">
      <div class="text-yellow-400 text-sm">
        {{ data.title }}
      </div>
      <div style="letter-spacing: 5px" class="flex items-center flex-col text-sm" v-if="data.indent2 && !data.indent3">
        {{ flow[data.indent1][data.indent2] }}
      </div>
      <div style="letter-spacing: 5px" class="flex items-center flex-col text-sm" v-if="data.indent3">
        {{ flow[data.indent1][data.indent2][data.indent3] }}
      </div>
    </div>
  </div>
</template>
