using s_des.Constants;

namespace s_des.Class;

// map permutations to an enum of permutations

public static class Mapper
{
    public static BitBuffer MapPermutation(IReadOnlyList<int> permutation, BitBuffer buffer)
    {
        var result = new int[permutation.Count];
        for (var i = 0; i < permutation.Count; i++) result[i] = buffer.Buffer[permutation[i] - 1];

        return new BitBuffer(result);
    }

    public static BitBuffer MapWithSboxs(BitBuffer buffer)
    {
        // mapping left
        int[] mapping = {0, 3, 1, 2};
        var left = MapWithSbox(buffer.Left, SBox.S0, mapping);

        var right = MapWithSbox(buffer.Right, SBox.S1, mapping);

        return new BitBuffer(left.Concat(right).ToArray());
    }

    private static IEnumerable<int> MapWithSbox(BitBuffer buffer, int[,] sBox, int[] mapping)
    {
        // convert to 2d array
        var row = Convert.ToInt32($"{buffer.Buffer[mapping[0]]}{buffer.Buffer[mapping[1]]}", 2);
        var column = Convert.ToInt32($"{buffer.Buffer[mapping[2]]}{buffer.Buffer[mapping[3]]}", 2);
        // convert to binary form sBox[row, column]
        var s = Convert.ToString(sBox[row, column], 2);
        if (s.Length == 1) s = "0" + s;
        // convert to int array
        var result = new int[s.Length];
        for (var i = 0; i < s.Length; i++) result[i] = Convert.ToInt32(s[i].ToString());
        return result;
    }
}