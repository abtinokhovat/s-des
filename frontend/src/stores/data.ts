import { defineStore } from "pinia";
import init from "../../data.json";
import { BitBuffer, KeyGenerator, Transformer } from "s-des-ts";
import { APIResponse } from "~/types";
import { Root } from "s-des-ts/lib/entity/flow";

export const useDataStore = defineStore("data", {
  state: () => {
    return {
      plain: "10101010",
      secret: "1010101010",
      flow: init,
    };
  },
  getters: {
    plainBitArray(): BitBuffer {
      const plainBitArray: number[] = [];
      for (let i = 0; i < this.plain.length; i++) {
        plainBitArray.push(parseInt(this.plain[i], 2));
      }
      return new BitBuffer(plainBitArray);
    },
    secretBitArray(): number[] {
      const secretBitArray: number[] = [];
      for (let i = 0; i < this.secret.length; i++) {
        secretBitArray.push(parseInt(this.secret[i], 2));
      }
      return secretBitArray;
    },
  },
  actions: {
    setPlain(val: string): void {
      const maxPlainLength = 8;
      this.plain = this.normalize(maxPlainLength, val);
      this.update();
    },
    setSecret(val: string): void {
      const maxSecretLength = 10;
      this.secret = this.normalize(maxSecretLength, val);
      this.update();
    },
    normalize(length: number, value: string): string {
      const initLength = value.length;
      if (initLength < length)
        for (let i = 0; i < length - initLength; i++) value += "0";
      return value;
    },

    update() {
      const [keys, keyRoot] = KeyGenerator.Generate(this.secretBitArray);
      const [cipher, encryptRoot] = Transformer.Encrypt(
        this.plainBitArray,
        keys
      );
      const [_, decryptRoot] = Transformer.Decrypt(cipher, keys);

      const root = new Root();
      root.KeyGeneration = keyRoot;
      root.Decryption = decryptRoot;
      root.Encryption = encryptRoot;

      this.flow = root as APIResponse;
    },
  },
});
