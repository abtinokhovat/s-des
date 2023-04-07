export default class BitBuffer {
  /**
   * BitBuffer class is the core class for computational process,
   * shifting.
   *
   * @param MaxHalfSize - Half the size that `BitBuffer` can store
   * @param _buffer - Private property that the main data will be stored in.
   * @param _left - Left part of `_buffer`, type of this property is `BitBuffer`
   * and the size is half of the `_buffer`.
   * @param _right - Right part of `_buffer`, type of this property is `BitBuffer`
   * and the size is half of the `_buffer`.
   */
  private static readonly MaxHalfSize = 5;
  private _left: BitBuffer | undefined = undefined;
  private _right: BitBuffer | undefined = undefined;
  private _buffer: Array<number> = [];

  public get buffer(): Array<number> {
    return this._buffer;
  }
  public set buffer(value: Array<number>) {
    this._buffer = value;
    this.length = value.length;

    if (value.length < BitBuffer.MaxHalfSize || value.length % 2 !== 0) return;

    this.left = new BitBuffer(this._buffer.slice(0, this.length / 2));
    this.right = new BitBuffer(
      this._buffer.slice(this.length / 2, this.length)
    );
  }

  public length: number = 0;

  public get left(): BitBuffer | undefined {
    return this._left;
  }

  public set left(value: BitBuffer | undefined) {
    this._left = value;
    // add updated left to main buffer
    if (this.length < BitBuffer.MaxHalfSize) return;
    if (value) {
      for (let i = 0; i < value.length; i++) {
        this.buffer[i] = value.buffer[i];
      }
    }
  }

  public get right(): BitBuffer | undefined {
    return this._right;
  }

  public set right(value: BitBuffer | undefined) {
    this._right = value;
    if (this.length < BitBuffer.MaxHalfSize) return;
    if (value) {
      for (let i = 0; i < value.length; i++) {
        this.buffer[i + value.length] = value.buffer[i];
      }
    }
  }

  public constructor(buffer: Array<number>);
  public constructor(length: number);
  public constructor(left: Array<number>, right: Array<number>);
  public constructor(param1: Array<number> | number, param2?: Array<number>) {
    if (Array.isArray(param1)) {
      if (param2 === undefined) {
        this.length = param1.length;
        this.buffer = param1;
      } else {
        // check both left and right for equal length
        if (param1.length !== param2.length)
          throw new Error("Left and right halves must be of equal length");

        // add length
        this.length = param1.length + param2.length;

        // fill main buffer with concat values
        this.buffer = [...param1, ...param2];

        // fill right and left halves
        this.left = new BitBuffer(param1);
        this.right = new BitBuffer(param2);
      }
    } else {
      BitBuffer.checkLength(param1);
      this.length = param1;
      this.buffer = new Array(param1).fill(0);
    }
  }

  //a function for limit length inputs of the class
  private static checkLength(length: number): void {
    // Check if the length is valid
    const maxLength = 10;
    if (length > maxLength)
      throw new Error("Length must be less than " + maxLength);
  }

  // a function for left shifting by N
  public shiftLeft(child: BitBuffer, position: number): BitBuffer {
    // Check if the shift is valid
    if (position > child.length)
      throw new Error("Shift must be less than " + child.length);

    // Shift the buffer
    const newBuffer = new Array<number>(child.length);
    for (let i = 0; i < child.length; i++) {
      let index = i + position;
      if (index >= child.length) index -= child.length;
      newBuffer[i] = child.buffer[index];
    }

    return new BitBuffer(newBuffer);
  }

  public leftShiftLeft(position: number): void {
    if (!this.left) throw new Error(`Left Buffer is ${this.left}`);
    this.left = this.shiftLeft(this.left, position);
  }

  public leftShiftRight(position: number): void {
    if (!this.right) throw new Error(`Right Buffer is ${this.right}`);
    this.right = this.shiftLeft(this.right, position);
  }

  // Swap left part and right part of buffer
  public swap(): BitBuffer {
    [this.left, this.right] = [this.right, this.left];
    return this;
  }

  // xor all bits of two buffers
  public xor(second: BitBuffer): BitBuffer {
    const newBuffer = new Array<number>(this.length);
    for (let i = 0; i < this.length; i++)
      newBuffer[i] = this.buffer[i] ^ second.buffer[i];
    return new BitBuffer(newBuffer);
  }

  // stringify the Buffer part of the class
  public toString(): string {
    let stringed = "";
    for (let i = 0; i < this.length; i++) stringed += `${this.buffer[i]}`;
    return stringed;
  }
}
