using s_des.Entity;

namespace s_des.Class;

public static class Main
{
    public static Root MakeWithString(string plain, string key)
    {
        var plainBitArray = plain.Select(i => Convert.ToInt32(i) - 48).ToArray();
        var secretBitArray = key.Select(i => Convert.ToInt32(i) - 48).ToArray();
        return Main.Make(plainBitArray,secretBitArray);
    }
    
    public static Root Make(int[] plain, int[] secret)
    {

        // key generation
        var keys = KeyGenerator.Generate(secret);
        var keyGenRes = keys.Item2;

        // encryption
        var cipher = Transformer.Encrypt(new BitBuffer(plain), keys.Item1);
        var cipherRes = cipher.Item2;

        // decryption
        var decrypt = Transformer.Decrypt(cipher.Item1, keys.Item1);
        var decryptRes = decrypt.Item2;
        
        return new Root()
        {
            KeyGeneration = keyGenRes,
            Encryption = cipherRes,
            Decryption = decryptRes
        };
    }
}