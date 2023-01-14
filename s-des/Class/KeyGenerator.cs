using s_des.Constants;
using s_des.Entity;
using s_des.Helper;

namespace s_des.Class;

public static class KeyGenerator
{
    public static Tuple<Keys,KeyGeneration> Generate(int[] secretBitArray, bool debug = true)
    {
        var p = new Printer();
        var secret = new BitBuffer(secretBitArray);
        var root = new KeyGeneration();

        // Rearrange secret using P10
        var main = Mapper.MapPermutation(Permutation.P10, secret);
        root.P10 = main.ToString();

        // Left Shift by 1 Left Half
        main.LeftShiftLeft(1);
        root.LS1_L = main.Left.ToString();

        // Left Shift by 1 Right Half
        main.LeftShiftRight(1);
        root.LS1_R = main.Right.ToString();

        // Permuted by p8
        var key1 = Mapper.MapPermutation(Permutation.P8, main);
        root.P8_1 = key1.ToString();
        // ------------------------ Key 1 Generated --------------------- 

        // Left Shift by 2 Left Half
        main.LeftShiftLeft(2);
        root.LS2_L = main.Left.ToString();

        // Left Shift by 2 Right Half
        main.LeftShiftRight(2);
        root.LS2_R = main.Right.ToString();

        // Permuted by p8
        var key2 = Mapper.MapPermutation(Permutation.P8, main);
        root.P8_2 = key2.ToString();
        // ------------------------ Key 2 Generated ---------------------

        var keys = new Keys(key1, key2);
        return new Tuple<Keys, KeyGeneration>(keys, root);
    }
}