using s_des.Class;
using s_des.Constants;

// key generation
int[] secretBitArray = {1, 0, 1, 0, 0, 0, 0, 0, 1, 0};
var keys = KeyGenerator.Generate(secretBitArray,true);

int[] plainBits = {0, 1, 1, 1, 0, 0, 1, 0};
var plain = new BitBuffer(plainBits);

// encryption
var cipher = Encryptor.Encrypt(plain, keys);


    

