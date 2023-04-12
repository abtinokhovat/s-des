import BitBufferArray from "../class/BitBufferArray";
import BitBuffer from "../class/BitBuffer";

/**
  Extends the String class by adding the toBinary and padStart methods.
 */

declare global {
  interface String {
    toBinary(): BitBufferArray;
    padStart(targetLength: number, padString: string): string;
  }
}

/**
  Converts a string to a BitBufferArray, where each character of the string is represented as a BitBuffer.
  @returns {BitBufferArray} - A BitBufferArray object containing BitBuffer representations of each character in the string.
*/

String.prototype.toBinary = function () {
  const result = new BitBufferArray();
  for (let i = 0; i < this.length; i++) {
    const charCode = this.charCodeAt(i);
    const binary = charCode.toString(2);
    const string = binary.padStart(8, "0") as string;
    const buffer = new BitBuffer(Array.from(string).map(Number));
    result.push(buffer);
  }

  return result;
};

/**
 Pads the current string with another string until it reaches the specified length.
 @param {number} maxLength - The length to pad the string to.
 @param {string} fillString - The string to use as padding. If this string is longer than one character, the first character will be used as the padding.
 @returns {string} - A padded string.
 */

String.prototype.padStart = function (
  maxLength: number,
  fillString: string
): string {
  let str = this.toString();
  while (str.length < maxLength) {
    str = fillString + str;
  }
  return str;
};
