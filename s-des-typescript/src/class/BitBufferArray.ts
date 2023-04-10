import BitBuffer from "./BitBuffer";

export default class BitBufferArray extends Array<BitBuffer> {
  toString(): string {
    return this.map((buffer) => buffer.toString()).join("-");
  }
}
