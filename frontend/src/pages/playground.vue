<script setup lang="ts">
import { Cryptography } from "s-des-ts";

const plain = ref("");
const secret = ref("");
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
  <div class="block">
    <div class="flex flex-col">
      <span> Plain Text </span>
      <textarea v-model="plain" class="border-1 rounded-md" name="plain">
      </textarea>
    </div>
    <div class="ml-6">
      <span>Bit Representation Plain Text </span>
      <div class="binary">
        {{ bitArrayPlain }}
      </div>
    </div>
  </div>
  <div>
    <span> Secret Bits </span>
    <input v-model="secret" class="border-1 rounded-md" name="plain" />
  </div>
  <div class="block">
    <div class="flex flex-col">
      <span> Cipher Text </span>
      <textarea v-model="cipher" class="border-1 rounded-md" name="plain">
      </textarea>
    </div>
    <div class="ml-6">
      <span>Bit Representation Cipher </span>
      <div class="binary">{{ bitArrayCipher }}</div>
    </div>
  </div>
</template>

<style scoped>
.block {
  @apply border-2 rounded-md border-yellow-400 border-dashed flex flex-col md:flex-row lg:flex-row p-2 bg-gray-200 dark:bg-gray-600;
}

.binary {
  @apply text-green-400 bg-transparent rounded-md w-xs max-h-[150px] overflow-y-scroll;
}

textarea {
  height: 150px;
  outline: none;
  padding: 2px;
}
</style>
