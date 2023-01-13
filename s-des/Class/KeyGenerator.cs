using s_des.Constants;
using s_des.Entity;
using s_des.Helper;

namespace s_des.Class;

public static class KeyGenerator
{
    public static Keys Generate(int[] secretBitArray, bool debug = true)
    {
        var p = new Printer();
        var secret = new BitBuffer(secretBitArray);

        // Rearrange secret using P10
        var main = Mapper.MapPermutation(Permutation.P10, secret);
        p.DebugPrint($"P10\n{main}");

        // Left Shift by 1 Left Half
        main.LeftShiftLeft(1);
        p.DebugPrint($"LS1-L\n{main.Left}");

        // Left Shift by 1 Right Half
        main.LeftShiftRight(1);
        p.DebugPrint($"LS1-R\n{main.Right}");

        // Permuted by p8
        var key1 = Mapper.MapPermutation(Permutation.P8, main);
        p.DebugPrint($"P8\n{key1}");
        p.DebugPrint($"Key1={key1}");
        p.DebugPrint("------------------------ Key 1 Generated ------------------------");
        // ------------------------ Key 1 Generated --------------------- 

        // Left Shift by 2 Left Half
        main.LeftShiftLeft(2);
        p.DebugPrint($"LS2-L\n{main.Left}");

        // Left Shift by 2 Right Half
        main.LeftShiftRight(2);
        p.DebugPrint($"LS2-R\n{main.Right}");

        // Permuted by p8
        var key2 = Mapper.MapPermutation(Permutation.P8, main);
        p.DebugPrint($"P8\n{key2}");
        p.DebugPrint($"Key2 = {key2}");

        p.DebugPrint("------------------------ Key 2 Generated ------------------------");
        // ------------------------ Key 2 Generated ---------------------

        return new Keys(key1, key2);
    }
}