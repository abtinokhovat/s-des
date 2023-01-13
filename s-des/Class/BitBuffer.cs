namespace s_des.Class;

public class BitBuffer
{
    private const int MaxHalfSize = 5;
    private int[] _buffer;
    private BitBuffer _left;
    private BitBuffer _right;

    public BitBuffer(int[] buffer)
    {
        Length = buffer.Length;
        Buffer = buffer;
    }

    public BitBuffer(int length)
    {
        CheckLength(length);
        Length = length;
        Buffer = new int[length];
    }

    public BitBuffer(int[] left, int[] right)
    {
        // check both left and right for equal length
        if (left.Length != right.Length) throw new Exception("Left and right halves must be of equal length");
        // add length
        Length = left.Length + right.Length;
        // fill main buffer with concat values
        Buffer = left.Concat(right).ToArray();
        // fill right and left halves
        Left = new BitBuffer(left);
        Right = new BitBuffer(right);
    }

    public int[] Buffer
    {
        get => _buffer;
        private set
        {
            _buffer = value;
            Length = value.Length;

            if (Length < MaxHalfSize) return;
            Left = new BitBuffer(_buffer.Take(Length / 2).ToArray());
            Right = new BitBuffer(_buffer.Skip(Length / 2).Take(Length / 2).ToArray());
        }
    }

    public int Length { get; private set; }

    public BitBuffer Left
    {
        get => _left;
        private set
        {
            _left = value;
            // add updated left to main buffer
            if (Length < MaxHalfSize) return;
            for (var i = 0; i < _left.Length; i++)
                Buffer[i] = _left.Buffer[i];
        }
    }

    public BitBuffer Right
    {
        get => _right;
        private set
        {
            _right = value;
            if (Length < MaxHalfSize) return;
            for (var i = 0; i < _right.Length; i++)
                Buffer[i + _right.Length] = _right.Buffer[i];
        }
    }

    //a function for limit length inputs of the class 
    private static void CheckLength(int length)
    {
        // Check if the length is valid
        const int maxLength = 10;
        if (length > maxLength)
            throw new Exception("Length must be less than " + maxLength);
    }

    // a function for left shifting by N 
    private BitBuffer ShiftLeft(BitBuffer child, int position)
    {
        // Check if the shift is valid
        if (position > child.Length)
            throw new Exception("Shift must be less than " + child.Length);

        // Shift the buffer
        var newBuffer = new int[child.Length];
        for (var i = 0; i < child.Length; i++)
        {
            var index = i + position;
            if (index >= child.Length)
                index -= child.Length;
            newBuffer[i] = child.Buffer[index];
        }

        return new BitBuffer(newBuffer);
    }

    public void LeftShiftLeft(int position)
    {
        var sl = ShiftLeft(Left, position);
        Left = sl;
    }

    public void LeftShiftRight(int position)
    {
        var sr = ShiftLeft(Right, position);
        Right = sr;
    }

    // Swap left part and right part of buffer
    public BitBuffer Swap()
    {
        (Left, Right) = (Right, Left);
        return this;
    }

    // xor all bits of two buffers
    public BitBuffer Xor(BitBuffer second)
    {
        var newBuffer = new int[Length];
        for (var i = 0; i < Length; i++) newBuffer[i] = Buffer[i] ^ second.Buffer[i];
        return new BitBuffer(newBuffer);
    }

    // stringify the Buffer part of the class
    public override string ToString()
    {
        var stringified = "";
        for (var i = 0; i < Length; i++)
            stringified += $"{Buffer[i]}";
        return stringified;
    }
}