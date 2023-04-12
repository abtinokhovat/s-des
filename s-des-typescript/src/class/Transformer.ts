import BitBuffer from "./BitBuffer";
import Mapper from "./Mapper";
import { Permutation } from "../constants/permutation";
import { FK, Transform } from "../entity/flow";
import { Keys } from "../entity/keys";

/**
 * Class representing s-des Network cipher transformer.
 */
export default class Transformer {
  /**
   * Performs the s-des function on the right half of the initial permutation.
   *
   * @param {BitBuffer} key - The key to use for the s-des function.
   * @param {BitBuffer} ip - The initial permutation.
   * @returns {[BitBuffer, FK]} An array containing the left half of the initial permutation after the s-des function and an object containing the intermediate results.
   */
  static Fk(key: BitBuffer, ip: BitBuffer): [BitBuffer, FK] {
    // expand by permutation
    const expanded = Mapper.MapPermutation(Permutation.EP, ip.right!);
    // xor with key
    const xor = expanded.xor(key);

    // map to sboxes
    const sboxMapped = Mapper.MapWithSboxs(xor);

    // map to permutation p4
    const p4 = Mapper.MapPermutation(Permutation.P4, sboxMapped);

    // xor p4 with left half of initial permutation
    const leftHalf = ip.left!.xor(p4);

    const root: FK = {
      EP: expanded.toString(),
      XOR_1: xor.toString(),
      Sbox: sboxMapped.toString(),
      P4: p4.toString(),
      XOR_2: leftHalf.toString(),
    };

    return [leftHalf, root];
  }

  /**
   * Transforms the input using s-des Network cipher.
   *
   * @param {BitBuffer} cipher - The input to transform.
   * @param {Keys} keys - The keys to use for the transformation.
   * @param {boolean} decrypt - If true, decrypts the input; otherwise, encrypts the input.
   * @returns {[BitBuffer, Transform]} An array containing the transformed output and an object containing the intermediate results.
   */
  static Transform(
    cipher: BitBuffer,
    keys: Keys,
    decrypt: boolean
  ): [BitBuffer, Transform] {
    // keys
    const key1 = decrypt ? keys.key2 : keys.key1;
    const key2 = decrypt ? keys.key1 : keys.key2;

    // initial permutation
    const ip = Mapper.MapPermutation(Permutation.IP, cipher);

    // call fk function
    const fk1 = Transformer.Fk(key1, ip);

    // swap variables
    const swap = new BitBuffer(ip.right!.buffer, fk1[0].buffer);

    // call fk function
    const fk2 = Transformer.Fk(key2, swap);

    // combine ip right half and fk result
    const combined = new BitBuffer(fk2[0].buffer, swap.right!.buffer);

    // ip inverse
    const ipInverse = Mapper.MapPermutation(Permutation.IP_1, combined);

    const root: Transform = {
      IP: ip.toString(),
      FK_1: fk1[1],
      SW: swap.toString(),
      FK_2: fk2[1],
      Combined: combined.toString(),
      IP_1: ipInverse.toString(),
    };

    return [ipInverse, root];
  }

  /**
   * Decrypts the input using s-des Network cipher.
   *
   * @param {BitBuffer} cipher - The input to decrypt.
   * @param {Keys} keys - The keys to use for decryption.
   * @returns {[BitBuffer, Transform]} An array containing the decrypted output and an object containing the intermediate results.
   */

  static Decrypt(cipher: BitBuffer, keys: Keys): [BitBuffer, Transform] {
    return Transformer.Transform(cipher, keys, true);
  }

  /**
   * Encrypts the input using s-des Network cipher.
   *
   * @param {BitBuffer} plain - The input to encrypt.
   * @param {Keys} keys - The keys to use for encryption.
   * @returns {[BitBuffer, Transform]} An array containing the encrypted output and an object containing the intermediate results.
   */
  static Encrypt(plain: BitBuffer, keys: Keys): [BitBuffer, Transform] {
    return Transformer.Transform(plain, keys, false);
  }
}
