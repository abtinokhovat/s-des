import BitBuffer from './BitBuffer';

export default class BitBufferArray extends Array<BitBuffer> {
  /**
   * Converts a binary string to an ASCII string.
   *
   * @returns The ASCII string.
   */

  public toAscii(): string {
    let asciiString = '';
    for (let i = 0; i < this.length; i++) {
      const byte = this.slice(i, i + 8);
      const charCode = parseInt(byte.toString(), 2);
      const char = String.fromCharCode(charCode);
      asciiString += char;
    }
    return asciiString;
  }
  toString(): string {
    return this.map((buffer) => buffer.toString()).join('-');
  }
}
