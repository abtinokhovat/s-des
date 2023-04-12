import Cryptography from "./class/Cryptography";

const string = "Hello,World but encrypted with s-des";
const secret = [1, 0, 0, 0, 1, 0, 1, 1, 1, 0];

const keys = Cryptography.GenerateKey(secret);
const cipher = Cryptography.Encryption(string, keys);

console.log(`Cipher Bits:${cipher.toString()}`);
console.log(`Cipher Ascii:${cipher.toAscii()}`);

const plain = Cryptography.Decryption(cipher, keys);

console.log(`Plain Text Decrypted:${plain}`);
