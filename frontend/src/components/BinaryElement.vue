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
      'text-[#69953d] no-underline': type === 'cipher',
    }"
    class="text-left cursor-pointer w-90px text-xs p-1 text-[#569bd5] underline"
    @click="route"
  >
    <span>
      {{ binary }}
    </span>
  </div>
</template>
