using s_des.Constants;
using s_des.Entity;

namespace s_des.Class;

public static class Transformer
{
    public static Tuple<BitBuffer,FK> Fk(BitBuffer key, BitBuffer ip)
    {
        // expand by permutation
        var expanded = Mapper.MapPermutation(Permutation.EP, ip.Right);

        // xor with key
        var xor = expanded.Xor(key);

        // map to sboxes
        var sboxMapped = Mapper.MapWithSboxs(xor);

        // map to permutation p4
        var p4 = Mapper.MapPermutation(Permutation.P4, sboxMapped);

        // xor p4 with left half of initial permutation
        var leftHalf = ip.Left.Xor(p4);
        
        var root = new FK()
        {
            EP = expanded.ToString(),
            XOR_1 = xor.ToString(),
            Sbox = sboxMapped.ToString(),
            P4 = p4.ToString(),
            XOR_2 = leftHalf.ToString(),
        };
        
        return new Tuple<BitBuffer, FK>(leftHalf, root);
    }

    private static Tuple<BitBuffer,Transform> Transform(BitBuffer cipher, Keys keys, bool decrypt)
    {
        // keys
        var key1 = decrypt ? keys.Key2 : keys.Key1;
        var key2 = decrypt ? keys.Key1 : keys.Key2;

        // initial permutation
        var ip = Mapper.MapPermutation(Permutation.IP, cipher);

        // call fk function
        var fk1 = Fk(key1, ip);
        
        // swap variables
        var swap = new BitBuffer(ip.Right.Buffer, fk1.Item1.Buffer);
        
        // call fk function
        var fk2 = Fk(key2, swap);
        
        // combine ip right half and fk result
        var combined = new BitBuffer(fk2.Item1.Buffer, swap.Right.Buffer);

        // ip inverse 
        var ip_1 = Mapper.MapPermutation(Permutation.IP_1, combined);

        var root = new Transform
        {
            IP = ip.ToString(),
            FK_1 = fk1.Item2,
            SW = swap.ToString(),
            FK_2 = fk2.Item2,
            Combined = combined.ToString(),
            IP_1 = ip_1.ToString()
        };

        return new Tuple<BitBuffer, Transform>(ip_1, root);
    }

    public static Tuple<BitBuffer,Transform> Decrypt(BitBuffer cipher, Keys keys)
    {
        return Transform(cipher, keys, true);
    }

    public static Tuple<BitBuffer,Transform> Encrypt(BitBuffer plain, Keys keys)
    {
        return Transform(plain, keys, false);
    }
}