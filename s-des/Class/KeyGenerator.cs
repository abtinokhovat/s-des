using s_des.Constants;
using s_des.Entity;

namespace s_des.Class;

public static class KeyGenerator
{
    public static Keys Generate(int[] secretBitArray, bool debug = false)
    {
        var secret = new BitBuffer(secretBitArray);

        // Rearrange secret using P10
        var main = Mapper.MapPermutation(Permutation.P10, secret);
        if (debug) Console.WriteLine($"Rearrange secret using P10 = {main}\n");

        // Left Shift by 1 Left Half
        main.LeftShiftLeft(1);
        if (debug) Console.WriteLine($"Left Shift by 1 Left Half = {main}\n");

        // Left Shift by 1 Right Half
        main.LeftShiftRight(1);
        if (debug) Console.WriteLine($"Left Shift by 1 Right Half = {main}\n");

        // Permuted by p8
        var key1 = Mapper.MapPermutation(Permutation.P8, main);
        if (debug) Console.WriteLine($"Permuted by p8, Key1 = {key1}\n");
        if (debug) Console.WriteLine("------------------------ Key 1 Generated ------------------------\n");
        // ------------------------ Key 1 Generated --------------------- 

        // Left Shift by 2 Left Half
        main.LeftShiftLeft(2);
        if (debug) Console.WriteLine($"Left Shift by 2 Left Half = {main}\n");

        // Left Shift by 2 Right Half
        main.LeftShiftRight(2);
        if (debug) Console.WriteLine($"Left Shift by 2 Left Half = {main}\n");

        // Permuted by p8
        var key2 = Mapper.MapPermutation(Permutation.P8, main);
        if (debug) Console.WriteLine($"Permuted by p8, Key2 = {key2}\n");

        if (debug) Console.WriteLine("------------------------ Key 2 Generated ------------------------\n");
        // ------------------------ Key 2 Generated ---------------------

        return new Keys(key1, key2);
    }
}