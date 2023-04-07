import { Mapper } from "./Mapper";
import { Permutation } from "../constants/permutation";
import { KeyGeneration } from "../entity/flow";
import BitBuffer from "./BitBuffer";
import { Keys } from "../entity/keys";

export class KeyGenerator {
  static generate(secretBitArray: Array<number>): [Keys, KeyGeneration] {
    const secret = new BitBuffer(secretBitArray);
    const root = new KeyGeneration();

    // Rearrange secret using P10
    let main = Mapper.MapPermutation(Permutation.P10, secret);
    root.P10 = main.toString();

    // Left Shift by 1 Left Half
    main.leftShiftLeft(1);
    root.LS1_L = main.left!.toString();

    // Left Shift by 1 Right Half
    main.leftShiftRight(1);
    root.LS1_R = main.right!.toString();

    // Permuted by p8
    const key1 = Mapper.MapPermutation(Permutation.P8, main);
    root.P8_1 = key1.toString();
    // ------------------------ Key 1 Generated ---------------------

    // Left Shift by 2 Left Half
    main.leftShiftLeft(2);
    root.LS2_L = main.left!.toString();

    // Left Shift by 2 Right Half
    main.leftShiftRight(2);
    root.LS2_R = main.right!.toString();

    // Permuted by p8
    const key2 = Mapper.MapPermutation(Permutation.P8, main);
    root.P8_2 = key2.toString();
    // ------------------------ Key 2 Generated ---------------------

    const keys = new Keys(key1, key2);
    return [keys, root];
  }
}
