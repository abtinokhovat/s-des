using s_des.Constants;
using s_des.Entity;

namespace s_des.Class;

public static class Transformer
{
    public static Response<BitBuffer> Fk(BitBuffer key, BitBuffer ip)
    {
        var strings = new SuperDic(); 
        strings.Add("FK", "Start");

        Console.WriteLine("------------------------ FK Start ------------------------\n");
        var expanded = Mapper.MapPermutation(Permutation.EP, ip.Right);
        Console.WriteLine($"EP\n{expanded}\n");
        strings.Add("EP", expanded.ToString());

        var xor = expanded.Xor(key);
        Console.WriteLine($"XOR\n{xor}\n");
        strings.Add("XOR", xor.ToString());

        var sboxMapped = Mapper.MapWithSboxs(xor);
        Console.WriteLine($"Sbox\n{sboxMapped}\n");
        strings.Add("Sbox", sboxMapped.ToString());

        var p4 = Mapper.MapPermutation(Permutation.P4, sboxMapped);
        Console.WriteLine($"P4\n{p4}\n");
        strings.Add("P4", p4.ToString());

        var leftHalf = ip.Left.Xor(p4);
        Console.WriteLine($"XOR\n{leftHalf}\n");
        strings.Add("XOR", leftHalf.ToString());


        strings.Add("FK", "Ended");
        Console.WriteLine("------------------------ FK Generated ------------------------\n");
        return new Response<BitBuffer>(leftHalf, strings);
    }

    private static Response<BitBuffer> Transform(BitBuffer cipher, Keys keys, bool decrypt)
    {
        var strings = new SuperDic();
        var isDecryptString = decrypt ? "Decrypted" : "Encrypted";
        strings.Add(isDecryptString, "Start");

        // keys
        var key1 = decrypt ? keys.Key2 : keys.Key1;
        var key2 = decrypt ? keys.Key1 : keys.Key2;

        // initial permutation
        var ip = Mapper.MapPermutation(Permutation.IP, cipher);
        Console.WriteLine($"IP\n{ip}\n");
        strings.Add("IP", ip.ToString());

        // call fk function
        var fk1 = Fk(key1, ip);
        strings.Concat(fk1.Results);
        Console.WriteLine($"FK1\n{fk1}\n");
        strings.Add("FK1", fk1.Exit.ToString());

        var swap = new BitBuffer(ip.Right.Buffer, fk1.Exit.Buffer);
        Console.WriteLine($"SW\n{swap}\n");
        strings.Add("SW", swap.ToString());

        // call fk function
        var fk2 = Fk(key2, swap);
        strings.Concat(fk2.Results);
        Console.WriteLine($"FK2\n{fk2}\n");
        strings.Add("FK2", fk2.Exit.ToString());

        // combine ip right half and fk result
        var combined = new BitBuffer(fk2.Exit.Buffer, swap.Right.Buffer);
        Console.WriteLine($"Combined\n{combined}\n");
        strings.Add("Combined", combined.ToString());

        // ip inverse 
        var ip_1 = Mapper.MapPermutation(Permutation.IP_1, combined);
        Console.WriteLine($"IP-1\n{ip_1}\n");
        strings.Add("IP-1", ip_1.ToString());

        Console.WriteLine($"{isDecryptString}\n{ip_1}\n");
        strings.Add(isDecryptString, ip_1.ToString());
        strings.Add(isDecryptString, "Ended");

        return new Response<BitBuffer>(ip_1, strings);
    }

    public static Response<BitBuffer> Decrypt(BitBuffer cipher, Keys keys)
    {
        return Transform(cipher, keys, true);
    }

    public static Response<BitBuffer> Encrypt(BitBuffer plain, Keys keys)
    {
        return Transform(plain, keys, false);
    }
}