using s_des.Class;

//int[] secretBitArray = {1,0,1,0,1,0,1,0,1,0};
//int[] plainBits = {1,0,0,1,0,1,1,0};

Console.WriteLine("Insert 8-bit Plain Text");
var plain = Console.ReadLine();
var plainBitArray = plain!.Select(i => Convert.ToInt32(i) - 48).ToArray();

Console.WriteLine("Insert 10-bit Key");
var key = Console.ReadLine();
var secretBitArray = key!.Select(i => Convert.ToInt32(i) - 48).ToArray();

// key generation
var keys = KeyGenerator.Generate(secretBitArray,true);

// encryption
var cipher = Encryptor.Encrypt(plainBitArray, keys);

// decryption
Decryptor.Decrypt(cipher, keys);





    

