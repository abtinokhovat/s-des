namespace s_des.Class;

public class HalfBitBuffer
{
    private int[] _buffer;

    public HalfBitBuffer(int[] buffer)
    {
        Buffer = buffer;
    }

    public int[] Buffer
    {
        get => _buffer;
        set
        {
            _buffer = value;
            Length = _buffer.Length;
        }
    }

    public int Length { get; set; }

    // a function for left shifting by N 
    public HalfBitBuffer ShiftLeft(int position)
    {
        // Check if the shift is valid
        if (position > Length)
            throw new Exception("Shift must be less than " + Length);

        // Shift the buffer
        var newBuffer = new int[Length];
        for (var i = 0; i < Length; i++)
        {
            var index = i + position;
            if (index >= Length)
                index -= Length;
            newBuffer[i] = Buffer[index];
        }

        Buffer = newBuffer;
        return new HalfBitBuffer(newBuffer);
    }
}