using s_des.Constants;
using s_des.Entity;
using s_des.Helper;

namespace s_des.Class;

public static class KeyGenerator
{
    public static Response<Keys> Generate(int[] secretBitArray, bool debug = true)
    {
        var strings = new SuperDic();
        strings.Add("KeyGeneration", "Start");

        var p = new Printer();
        var secret = new BitBuffer(secretBitArray);

        // Rearrange secret using P10
        var main = Mapper.MapPermutation(Permutation.P10, secret);
        p.DebugPrint($"P10\n{main}");
        strings.Add("P10", main.ToString());

        // Left Shift by 1 Left Half
        main.LeftShiftLeft(1);
        p.DebugPrint($"LS1-L\n{main.Left}");
        strings.Add("LS1-L", main.Left.ToString());

        // Left Shift by 1 Right Half
        main.LeftShiftRight(1);
        p.DebugPrint($"LS1-R\n{main.Right}");
        strings.Add("LS1-R", main.Right.ToString());

        // Permuted by p8
        var key1 = Mapper.MapPermutation(Permutation.P8, main);
        p.DebugPrint($"P8\n{key1}");
        strings.Add("P8", key1.ToString());

        p.DebugPrint($"Key1={key1}");
        strings.Add("Key1", key1.ToString());

        p.DebugPrint("------------------------ Key 1 Generated ------------------------");
        // ------------------------ Key 1 Generated --------------------- 

        // Left Shift by 2 Left Half
        main.LeftShiftLeft(2);
        p.DebugPrint($"LS2-L\n{main.Left}");
        strings.Add("LS2-L", main.Left.ToString());

        // Left Shift by 2 Right Half
        main.LeftShiftRight(2);
        p.DebugPrint($"LS2-R\n{main.Right}");
        strings.Add("LS2-R", main.Right.ToString());

        // Permuted by p8
        var key2 = Mapper.MapPermutation(Permutation.P8, main);
        p.DebugPrint($"P8\n{key2}");
        strings.Add("P8", key2.ToString());

        p.DebugPrint($"Key2 = {key2}");
        strings.Add("Key2", key2.ToString());
        strings.Add("KeyGeneration", "Ended");

        p.DebugPrint("------------------------ Key 2 Generated ------------------------");
        // ------------------------ Key 2 Generated ---------------------

        var keys = new Keys(key1, key2);
        return new Response<Keys>(keys, strings);
    }
}