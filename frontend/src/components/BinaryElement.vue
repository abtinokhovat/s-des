<script setup lang="ts">
const router = useRouter();

const props = defineProps({
  binary: {
    type: String,
    required: true,
  },
  secret: {
    type: String,
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
});

function route() {
  if (props.type === "cipher") return;
  router.push({
    path: "/",
    query: { plain: props.binary, secret: props.secret },
  });
}
</script>

<template>
  <div
    :class="{
      'display-none': !binary,
      'border-green-400 bg-green-400! bg-opacity-70!': type === 'cipher',
    }"
    class="cursor-pointer w-90px text-xs p-1 text-white border-2 border-blue-400 rounded-md bg-light-blue-400"
    @click="route"
  >
    <span>
      {{ binary }}
    </span>
  </div>
</template>
