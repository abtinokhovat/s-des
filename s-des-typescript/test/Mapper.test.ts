import BitBuffer from "../src/class/BitBuffer";
import Mapper from "../src/class/Mapper";
import { Permutation } from "../src/constants/permutation";

describe("Mapper", () => {
  describe("MapPermutation", () => {
    it("should apply the permutation to the buffer", () => {
      const buffer = new BitBuffer([1, 0, 1, 0, 0, 1, 0, 1, 1, 1]);
      const result = Mapper.MapPermutation(Permutation.P10, buffer);
      expect(result.buffer).toEqual([1, 0, 0, 0, 0, 1, 1, 1, 1, 1]);
    });
  });

  describe("MapWithSboxs", () => {
    it("should apply the S-boxes to the buffer", () => {
      const buffer = new BitBuffer([1, 1, 1, 0, 1, 1, 0, 1]);
      const result = Mapper.MapWithSboxs(buffer);
      expect(result.buffer).toEqual([1, 1, 0, 0]);
    });
  });

  describe("MapWithSboxs", () => {
    it("should apply the S-boxes to the buffer", () => {
      const buffer = new BitBuffer([0, 1, 1, 1, 0, 0, 1, 0]);
      const result = Mapper.MapWithSboxs(buffer);
      expect(result.buffer).toEqual([0, 0, 0, 1]);
    });
  });
});
