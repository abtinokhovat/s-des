<script setup lang="ts">
const router = useRouter();

const props = defineProps({
  binary: {
    type: String,
    required: true,
  },
});

function route() {
  router.push({ path: "/", query: { plain: props.binary } });
}
</script>

<template>
  <div
    :class="{ 'display-none': !binary }"
    class="cursor-pointer p-1 text-white border-2 border-blue-400 rounded-md bg-light-blue-400"
    @click="route"
  >
    {{ binary }}
  </div>
</template>
