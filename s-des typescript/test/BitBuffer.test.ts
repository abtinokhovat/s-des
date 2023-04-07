import BitBuffer from "../src/class/BitBuffer";

describe("BitBuffer", () => {
  describe("constructor", () => {
    it("should create a new BitBuffer with the given buffer", () => {
      const buffer = [1, 0, 1, 0, 0, 1, 0, 1, 1, 1];
      const bitBuffer = new BitBuffer(buffer);
      expect(bitBuffer.buffer).toEqual(buffer);
      expect(bitBuffer.length).toBe(buffer.length);
    });

    it("should create a new BitBuffer with the given buffer", () => {
      const buffer = [1, 0, 1, 1, 0, 0, 1, 0];
      const bitBuffer = new BitBuffer(buffer);
      expect(bitBuffer.buffer).toEqual(buffer);
      expect(bitBuffer.length).toBe(buffer.length);
    });

    it("should create a new empty BitBuffer with the given length", () => {
      const length = 8;
      const bitBuffer = new BitBuffer(length);
      expect(bitBuffer.buffer).toEqual(new Array(length).fill(0));
      expect(bitBuffer.length).toBe(length);
    });

    it("should throw an error if the length is greater than the maximum allowed length", () => {
      const maxLength = 10;
      const length = maxLength + 1;
      expect(() => new BitBuffer(length)).toThrow(
        `Length must be less than ${maxLength}`
      );
    });

    it("should create a new BitBuffer with the given left and right buffers", () => {
      const left = [1, 0, 1, 1];
      const right = [0, 1, 0, 0];
      const buffer = [...left, ...right];
      const bitBuffer = new BitBuffer(left, right);
      expect(bitBuffer.buffer).toEqual(buffer);
      expect(bitBuffer.left.buffer).toEqual(left);
      expect(bitBuffer.right.buffer).toEqual(right);
      expect(bitBuffer.length).toBe(buffer.length);
    });
  });

  describe("LeftShiftLeft", () => {
    it("should shift the left buffer to the left by the given number of positions", () => {
      const buffer = [1, 0, 1, 1, 0, 0, 1, 0];
      const bitBuffer = new BitBuffer(buffer);
      bitBuffer.leftShiftLeft(2);
      expect(bitBuffer.buffer).toEqual([1, 1, 1, 0, 0, 0, 1, 0]);
    });

    it("should throw an error if the shift position is greater than the length of the buffer", () => {
      const buffer = [1, 0, 1, 1, 0, 0, 1, 0];
      const bitBuffer = new BitBuffer(buffer);
      expect(() => bitBuffer.leftShiftLeft(10)).toThrow(
        `Shift must be less than ${bitBuffer.length / 2}`
      );
    });
  });

  describe("shiftLeft", () => {
    it("should shift the buffer correctly", () => {
      const buffer = new BitBuffer([1, 0, 1, 1, 0, 1]);
      const shifted = buffer.shiftLeft(buffer, 2);
      expect(shifted.buffer.toString()).toEqual("1,1,0,1,1,0");
    });

    it("should throw an error if position is greater than length", () => {
      const buffer = new BitBuffer([1, 0, 1, 1, 0, 1]);
      expect(() => buffer.shiftLeft(buffer, 22)).toThrowError(
        `Shift must be less than ${buffer.length}`
      );
    });
  });

  describe("LeftShiftRight", () => {
    it("should shift the right half of the buffer to the right by the specified position", () => {
      const buffer = new BitBuffer([1, 0, 1, 1, 0, 1, 0, 0]);
      buffer.leftShiftRight(2);
      expect(buffer.toString()).toEqual("10110001");
    });
  });

  describe("Swap", () => {
    it("should swap the left and right halves of the buffer", () => {
      const buffer = new BitBuffer([1, 0, 1, 1, 0, 1, 0, 0]);
      buffer.swap();
      expect(buffer.toString()).toEqual("01001011");
    });
  });

  describe("Xor", () => {
    it("should xor two buffers together", () => {
      const buffer1 = new BitBuffer([1, 0, 1, 1, 0, 1, 0, 0]);
      const buffer2 = new BitBuffer([0, 1, 0, 1, 1, 0, 0, 1]);
      const result = buffer1.xor(buffer2);
      expect(result.toString()).toEqual("11101101");
    });
  });

  describe("ToString", () => {
    it("should return a string representation of the buffer", () => {
      const buffer = new BitBuffer([1, 0, 1, 1, 0, 1, 0, 0]);
      expect(buffer.toString()).toEqual("10110100");
    });
  });
});
