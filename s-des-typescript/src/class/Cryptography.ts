import Transformer from "./Transformer";
import { Keys } from "../entity/keys";
import KeyGenerator from "./KeyGenerator";
import BitBufferArray from "./BitBufferArray";
import "../extensions/string.extension";

//TODO:unit tests

export default class Cryptography {
  /**
   Generates a key using the provided secret array.
   @param {number[]} secret - The secret array used to generate the key. Must have a length of 10.
   @returns {Keys} - An object containing the generated keys.
   @throws {Error} - Throws an error if the secret array does not have a length of 10.
   */
  public static GenerateKey(secret: number[]): Keys {
    if (secret.length !== 10) throw new Error("Secret length should be 10.");
    const [keys, _] = KeyGenerator.generate(secret);
    return keys;
  }

  /**
   Encrypts the provided string using the provided keys.
   @param {string} string - The string to encrypt.
   @param {Keys} keys - An object containing the encryption keys.
   @returns {BitBuffer[]} - An array of BitBuffer objects representing the encrypted string.
   */
  public static Encryption(string: string, keys: Keys): BitBufferArray {
    const buffers = string.toBinary();
    const cipherBuffer = new BitBufferArray();
    for (const buffer of buffers) {
      const [cipherByte, _] = Transformer.Encrypt(buffer, keys);
      cipherBuffer.push(cipherByte);
    }
    return cipherBuffer;
  }

  /**
   Decrypts the provided cipher BitBuffer array using the provided keys.
   @param {BitBuffer[]} cipherBitArray - An array of BitBuffer objects representing the cipher to decrypt.
   @param {Keys} keys - An object containing the decryption keys.
   @returns {string} - The decrypted string.
   */
  public static Decryption(cipherBitArray: BitBufferArray, keys: Keys): string {
    const plainBytes = new BitBufferArray();
    for (const bitBuffer of cipherBitArray) {
      const [plainByte, _] = Transformer.Decrypt(bitBuffer, keys);
      plainBytes.push(plainByte);
    }
    return plainBytes.toAscii();
  }
}
