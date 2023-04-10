import BitBuffer from "./BitBuffer";
import BitBufferArray from "./BitBufferArray";

/**
 * Utility class for converting between binary and ASCII strings.
 */
export class BinaryUtil {
  /**
   * Converts a binary string to an ASCII string.
   * @param buffer The binary array in BitBuffer
   * @returns The ASCII string.
   */
  public static toAscii(buffer: BitBuffer[]): string {
    let asciiString = "";
    for (let i = 0; i < buffer.length; i++) {
      const byte = buffer.slice(i, i + 8);
      const charCode = parseInt(byte.toString(), 2);
      const char = String.fromCharCode(charCode);
      asciiString += char;
    }
    return asciiString;
  }

  /**
   * Converts an ASCII string to a binary string.
   * @param ascii The ASCII string to convert.
   * @returns The binary string.
   */
  public static toBinary(ascii: string): BitBufferArray {
    const result: BitBufferArray = [];

    for (let i = 0; i < ascii.length; i++) {
      const charCode = ascii.charCodeAt(i);
      const binary = charCode.toString(2);
      const string: string = this.padStart(binary, 8, "0");
      const buffer = new BitBuffer(Array.from(string).map(Number));
      result.push(buffer);
    }

    return result;
  }

  private static padStart(
    str: string,
    targetLength: number,
    padString: string = " "
  ): string {
    if (str.length >= targetLength) {
      return str;
    }
    const pads = Math.floor((targetLength - str.length) / padString.length);
    return (
      padString.repeat(pads) +
      padString.slice(0, targetLength - str.length - pads * padString.length) +
      str
    );
  }
}
