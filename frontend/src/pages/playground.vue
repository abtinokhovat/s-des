<script setup lang="ts">
import { Cryptography } from "s-des-ts";
import BinaryElementArray from "~/components/BinaryElementArray.vue";
import BitArrayInput from "~/components/BitArrayInput.vue";

const plain = ref("");
const secret = ref("0000000000");
const cipher = ref("");

const bitArrayPlain = ref("");
const bitArrayCipher = ref("");

function toNumberArray(str: string): number[] {
  const secretBitArray: number[] = [];
  for (let i = 0; i < str.length; i++) {
    secretBitArray.push(parseInt(str[i]));
  }
  return secretBitArray;
}

function encrypt() {
  if (secret.value.length !== 10) return;
  const keys = Cryptography.GenerateKey(toNumberArray(secret.value));
  const res = Cryptography.Encryption(plain.value, keys);
  cipher.value = res.toAscii();
}

function updateSecret(secretString: string) {
  secret.value = secretString;
}

watch(cipher, () => {
  bitArrayCipher.value = cipher.value.toBinary().toString();
  if (secret.value.length !== 10) return;
  const keys = Cryptography.GenerateKey(toNumberArray(secret.value));
  plain.value = Cryptography.Decryption(cipher.value.toBinary(), keys);
});

watch(secret, (value, oldValue) => {
  if (value.length > 10) secret.value = oldValue;
  encrypt();
});

watch(plain, () => {
  bitArrayPlain.value = plain.value.toBinary().toString();
  encrypt();
});
</script>

<template>
  <div class="grid gap-4 sm:grid-cols-2 sm:grid-rows-2">
    <div class="block order-1">
      <div class="flex flex-col">
        <span class="title"> Plain Text </span>
        <textarea v-model="plain" class="border-1 rounded-md" name="plain">
        </textarea>
      </div>
      <div class="ml-6 grow">
        <div class="m-2 title2">Bit Representation Plain Text</div>
        <binary-element-array
          :binary-array="bitArrayPlain as string"
          :secret="secret as string"
        />
      </div>
    </div>
    <div class="block order-3 md:order-2 lg:order-2">
      <div class="flex flex-col">
        <span class="title"> Cipher Text </span>
        <textarea v-model="cipher" class="border-1 rounded-md" name="plain">
        </textarea>
      </div>
      <div class="ml-6 grow">
        <div class="m-2 title2">Bit Representation Cipher</div>
        <binary-element-array
          type="cipher"
          :binary-array="bitArrayCipher as string"
        />
      </div>
    </div>
    <div
      class="flex flex-col mb-2 justify-self-center sm:h-full order-2 md:order-3 lg:order-3 lg:col-span-2"
    >
      <span class="title"> Secret Bits </span>
      <bit-array-input @on-change="updateSecret" />
    </div>
  </div>
</template>

<style scoped>
.block {
  @apply border-2 rounded-md border-yellow-400 border-dashed flex flex-col lg:flex-row justify-center p-7 bg-[#1d1d1d];
}

.title {
  @apply text-[#6c6c6c];
}

.title2 {
  @apply text-[#f7d959];
}

textarea {
  @apply bg-[#323232] border-[#d4d4d4] border-dashed text-[#c7c7c7];
  height: 150px;
  outline: none;
  padding: 2px;
}
</style>
