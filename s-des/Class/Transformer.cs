using s_des.Constants;
using s_des.Entity;

namespace s_des.Class;

public static class Transformer
{
    public static BitBuffer Fk(BitBuffer key, BitBuffer ip)
    {
        Console.WriteLine("------------------------ FK Start ------------------------\n");
        var expanded = Mapper.MapPermutation(Permutation.EP, ip.Right);
        Console.WriteLine($"EP\n{expanded}\n");

        var xor = expanded.Xor(key);
        Console.WriteLine($"XOR\n{xor}\n");

        var sboxMapped = Mapper.MapWithSboxs(xor);
        Console.WriteLine($"Sbox\n{sboxMapped}\n");

        var p4 = Mapper.MapPermutation(Permutation.P4, sboxMapped);
        Console.WriteLine($"P4\n{p4}\n");

        var leftHalf = ip.Left.Xor(p4);
        Console.WriteLine($"XOR\n{leftHalf}\n");

        Console.WriteLine("------------------------ FK Generated ------------------------\n");
        return leftHalf;
    }

    private static BitBuffer Transform(BitBuffer cipher, Keys keys,bool decrypt)
    {
        
        // keys
        var key1 = decrypt ? keys.Key2 : keys.Key1;
        var key2 = decrypt ? keys.Key1 : keys.Key2;
        
        // initial permutation
        var ip = Mapper.MapPermutation(Permutation.IP, cipher);
        Console.WriteLine($"IP\n{ip}\n");

        // call fk function
        var fk1 = Transformer.Fk(key1, ip);
        Console.WriteLine($"FK1\n{fk1}\n");

        var swap = new BitBuffer(ip.Right.Buffer, fk1.Buffer);
        Console.WriteLine($"SW\n{swap}\n");

        // call fk function
        var fk2 = Transformer.Fk(key2, swap);
        Console.WriteLine($"FK2\n{fk2}\n");

        // combine ip right half and fk result
        var combined = new BitBuffer(fk2.Buffer, swap.Right.Buffer);
        Console.WriteLine($"Combined\n{combined}\n");

        // ip inverse 
        var ip_1 = Mapper.MapPermutation(Permutation.IP_1, combined);
        Console.WriteLine($"IP-1\n{ip_1}\n");
        var isDecryptString = decrypt ? "Decrypted" : "Encrypted";
        Console.WriteLine($"{isDecryptString}\n{ip_1}\n");
        return ip_1;
    }

    public static BitBuffer Decrypt(BitBuffer cipher, Keys keys)
    {
        return Transform(cipher, keys, true);
    }
    
    public static BitBuffer Encrypt(BitBuffer cipher, Keys keys)
    {
        return Transform(cipher, keys, false);
    }
}