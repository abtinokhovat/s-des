import BitBuffer from "./BitBuffer";
import { SBox } from "../constants/sbox";

export default class Mapper {
  /**
   Utility class that provides methods for mapping bit buffers with given permutation or S-Box.
   */

  /**
   Maps the given BitBuffer with the provided permutation array.
   @param {ReadonlyArray<number>} permutation - The permutation array.
   @param {BitBuffer} buffer - The BitBuffer to be mapped.
   @returns {BitBuffer} A new BitBuffer mapped using the provided permutation array.
   */
  public static MapPermutation(
    permutation: ReadonlyArray<number>,
    buffer: BitBuffer
  ): BitBuffer {
    const result = new Array<number>(permutation.length);
    for (let i = 0; i < permutation.length; i++) {
      result[i] = buffer.buffer[permutation[i] - 1];
    }

    return new BitBuffer(result);
  }

  /**

   Maps the given BitBuffer with the provided S-Box array.
   @param {BitBuffer} buffer - The BitBuffer to be mapped.
   @returns {BitBuffer} A new BitBuffer mapped using the provided S-Box array.
   */
  public static MapWithSboxs(buffer: BitBuffer): BitBuffer {
    const mapping = [0, 3, 1, 2];
    const left = Mapper.MapWithSbox(buffer.left!, SBox.S0, mapping);
    const right = Mapper.MapWithSbox(buffer.right!, SBox.S1, mapping);
    const concatenated = left.concat(right);
    return new BitBuffer(concatenated);
  }

  /**

   Maps the given BitBuffer with the provided S-Box and mapping array.
   @param {BitBuffer} buffer - The BitBuffer to be mapped.
   @param {number[][]} sBox - The S-Box array.
   @param {number[]} mapping - The mapping array.
   @returns {number[]} An array of mapped values.
   @private
   */
  private static MapWithSbox(
    buffer: BitBuffer,
    sBox: number[][],
    mapping: number[]
  ): number[] {
    const row = parseInt(
      `${buffer.buffer[mapping[0]]}${buffer.buffer[mapping[1]]}`,
      2
    );
    const column = parseInt(
      `${buffer.buffer[mapping[2]]}${buffer.buffer[mapping[3]]}`,
      2
    );
    let s = sBox[row][column].toString(2);
    if (s.length === 1) s = `0${s}`;
    const result = new Array<number>(s.length);
    for (let i = 0; i < s.length; i++) {
      result[i] = parseInt(s[i], 10);
    }

    return result;
  }
}
