using s_des.Constants;
using s_des.Entity;

namespace s_des.Class;

public static class Encryptor
{
    public static BitBuffer Encrypt(int[] plainBits,Keys keys)
    {
        // convert bits to bit buffer
        var plain = new BitBuffer(plainBits);
        
        // initial permutation
        var ip = Mapper.MapPermutation(Permutation.IP, plain);
        Console.WriteLine($"Permuted by IP = {ip}\n");

        // call fk function
        var fk1 = Encryptor.Fk(keys.Key1, ip);
        Console.WriteLine($"FK result = {fk1}\n");

        var swap = new BitBuffer(ip.Right.Buffer,fk1.Buffer);
        Console.WriteLine($"Swapped = {swap}\n");

        // call fk function
        var fk2 = Encryptor.Fk(keys.Key2, swap);
        Console.WriteLine($"FK result = {fk2}\n");

        // combine ip right half and fk result
        var combined = new BitBuffer(fk2.Buffer,swap.Right.Buffer);
        Console.WriteLine($"Combined = {combined}\n");

        // ip inverse 
        var ip_1 = Mapper.MapPermutation(Permutation.IP_1, combined);
        Console.WriteLine($"IP Inverse,Cipher Text ={ip_1}\n");
        Console.WriteLine($"------------------------ Cipher Text ------------------------\n");
        return ip_1;
    }
    public static BitBuffer Fk(BitBuffer key,BitBuffer ip)
    {
        Console.WriteLine("------------------------ FK Start ------------------------\n");
        var expanded = Mapper.MapPermutation(Permutation.EP, ip.Right);
        Console.WriteLine($"Right half Permuted by EP = {expanded}\n");

        var xor = expanded.Xor(key);
        Console.WriteLine($"Right half XOR with Key = {xor}\n");

        var sboxMapped = Mapper.MapWithSboxs(xor);
        Console.WriteLine($"Mapped with S-Boxs = {sboxMapped}\n");

        var p4 = Mapper.MapPermutation(Permutation.P4, sboxMapped);
        Console.WriteLine($"Permuted by P4 = {p4}\n");

        var leftHalf = ip.Left.Xor(p4);
        Console.WriteLine($"Left half XOR with P4 = {leftHalf}\n");
        
        Console.WriteLine("------------------------ FK Generated ------------------------\n");
        return leftHalf;
    }
}