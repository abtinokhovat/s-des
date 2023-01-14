using s_des.Class;
using s_des.Entity;
using Formatting = Newtonsoft.Json.Formatting;

//int[] secretBitArray = {1,0,1,0,1,0,1,0,1,0};
//int[] plainBits = {1,0,0,1,0,1,1,0};

Console.WriteLine("Insert 8-bit Plain Text");
var plain = Console.ReadLine();
var plainBitArray = plain!.Select(i => Convert.ToInt32(i) - 48).ToArray();
Console.WriteLine("\n");

Console.WriteLine("Insert 10-bit Key");
var key = Console.ReadLine();
var secretBitArray = key!.Select(i => Convert.ToInt32(i) - 48).ToArray();
Console.WriteLine("\n");

// key generation
var keys = KeyGenerator.Generate(secretBitArray);
var keyGenRes = keys.Item2;

// encryption
var cipher = Transformer.Encrypt(new BitBuffer(plainBitArray), keys.Item1);
var cipherRes = cipher.Item2;

// decryption
var decrypt = Transformer.Decrypt(cipher.Item1, keys.Item1);
var decryptRes = decrypt.Item2;

var res =new Root()
{
    KeyGeneration = keyGenRes,
    Encryption = cipherRes,
    Decryption = decryptRes
};

Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(res, (Formatting) System.Xml.Formatting.Indented));