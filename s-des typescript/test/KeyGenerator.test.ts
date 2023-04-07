import { KeyGenerator } from "../src/class/KeyGenetor";
import BitBuffer from "../src/class/BitBuffer";

describe("KeyGenerator", () => {
  it("P10", () => {
    const secretBitArray = [1, 0, 1, 0, 1, 0, 1, 0, 1, 0];
    const [key, root] = KeyGenerator.generate(secretBitArray);
    console.log(root);
  });
  //
  // it("LS1_L", () => {
  //   expect(root.LS1_L).toEqual("10101");
  // });
  //
  // it("LS1_R", () => {
  //   expect(root.LS1_R).toEqual("11000");
  // });
  //
  // it("P8_1", () => {
  //   expect(root.P8_1).toEqual("11100100");
  // });
});
