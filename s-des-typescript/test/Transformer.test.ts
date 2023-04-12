import BitBuffer from "../src/class/BitBuffer";
import Transformer from "../src/class/Transformer";
import KeyGenerator from "../src/class/KeyGenerator";

describe("Transformer", () => {
  const secretBitArray = [1, 0, 1, 0, 1, 0, 1, 0, 1, 0];
  const plainText = new BitBuffer([1, 0, 1, 0, 1, 0, 1, 0]);

  const [keys] = KeyGenerator.Generate(secretBitArray);

  describe("Encrypt", () => {
    it("should encrypt plain text correctly", () => {
      const expectedCipher = new BitBuffer([0, 1, 1, 0, 1, 0, 1, 1]);
      const [cipher, _] = Transformer.Encrypt(plainText, keys);
      expect(cipher.toString()).toBe(expectedCipher.toString());
    });
  });

  describe("Decrypt", () => {
    it("should decrypt cipher text correctly", () => {
      const [cipher] = Transformer.Encrypt(plainText, keys);
      const [plain] = Transformer.Decrypt(cipher, keys);
      expect(plain.toString()).toBe(plainText.toString());
    });
  });
});
