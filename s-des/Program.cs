using s_des.Class;

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
var keyGenRes = keys.Results;

// encryption
var cipher = Transformer.Encrypt(new BitBuffer(plainBitArray), keys.Exit);
var cipherRes = cipher.Results;

// decryption
var decrypt = Transformer.Decrypt(cipher.Exit, keys.Exit);
var decryptRes = decrypt.Results;


var a = 10;