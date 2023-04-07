import BitBuffer from "./BitBuffer";
import { SBox } from "../constants/sbox";

export class Mapper {
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

  public static MapWithSboxs(buffer: BitBuffer): BitBuffer {
    const mapping = [0, 3, 1, 2];
    const left = Mapper.MapWithSbox(buffer.left!, SBox.S0, mapping);
    const right = Mapper.MapWithSbox(buffer.right!, SBox.S1, mapping);
    const concatenated = left.concat(right);
    return new BitBuffer(concatenated);
  }

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
      result[i] = parseInt(s[i]);
    }

    return result;
  }
}
