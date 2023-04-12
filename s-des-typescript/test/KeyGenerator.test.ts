import KeyGenerator from "../src/class/KeyGenerator";

describe("KeyGenerator", () => {
  const secretBitArray = [1, 0, 1, 0, 1, 0, 1, 0, 1, 0];
  const [key, root] = KeyGenerator.Generate(secretBitArray);

  it("P10", () => {
    expect(root.P10).toEqual("1101001100");
  });

  it("LS1_L", () => {
    expect(root.LS1_L).toEqual("10101");
  });

  it("LS1_R", () => {
    expect(root.LS1_R).toEqual("11000");
  });

  it("Key1 Test", () => {
    expect(root.P8_1).toEqual("11100100");
  });

  it("LS2_L", () => {
    expect(root.LS2_L).toEqual("10110");
  });

  it("LS2_R", () => {
    expect(root.LS2_R).toEqual("00011");
  });

  it("Key2 Test", () => {
    expect(root.P8_2).toEqual("01010011");
  });

  it("should throw an error if secret length is not 10", () => {
    const secret: number[] = [0, 1, 0, 1, 1, 0, 1, 0, 0];
    expect(() => KeyGenerator.Generate(secret)).toThrowError(
      "Secret length should be 10."
    );
  });

  it("should throw an error if any value in the secret bit array is invalid", () => {
    const secret: number[] = [0, 1, 0, 2, 1, 0, 1, 0, 0, 1];
    expect(() => KeyGenerator.Generate(secret)).toThrowError(
      "Invalid value in secret bit array."
    );
  });
});
