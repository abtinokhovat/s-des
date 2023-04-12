import BitBufferArray from "../class/BitBufferArray";
import BitBuffer from "../class/BitBuffer";

declare global {
  interface String {
    toBinary(): BitBufferArray;
    padStart(targetLength: number, padString: string): string;
  }
}

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
