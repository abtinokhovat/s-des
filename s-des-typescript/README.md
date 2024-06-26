This library provides an implementation of the Simplified Data Encryption Standard (S-DES) algorithm. S-DES is a simplified version of the original Data Encryption Standard (DES) algorithm and is a lightweight encryption algorithm suitable for educational purposes and low-level security requirements.

# S-DES Algorithm

S-DES algorithm operates on 8-bit blocks of data and uses a 10-bit secret key. The algorithm consists of several rounds of Feistel cipher and uses simple substitution and permutation operations. More information about the S-DES algorithm can be found on the internet.

# How to use the Cryptography class

The Cryptography class is the main class of this library and provides the following static methods:

`GenerateKey(secret: number[]): number[]`: Generates a 10-bit secret key from a 10-bit secret. The secret parameter is an array of 10 bits (0 or 1).
`Encrypt(plain: string, keys: Keys): BitBuffer`: Encrypts the given plain string using the provided `keys`. Returns a `BitBuffer` object containing the encrypted bits.
`Decrypt(cipher: BitBuffer, keys: Keys): string`: Decrypts the given cipher `BitBuffer` using the provided `keys`. Returns the decrypted plain text string.
Example
Here's an example of how to use the Cryptography class:

```javascript
import Cryptography from './class/Cryptography';

const string = 'Hello,World but encrypted with s-des';
const secret = [1, 0, 0, 0, 1, 0, 1, 1, 1, 0];

const keys = Cryptography.GenerateKey(secret);
const cipher = Cryptography.Encrypt(string, keys);

console.log(`Cipher Bits:${cipher.toString()}`);

// Cipher Bits:
// 00010111-10101001-11011010-11011010-01100100-01101110-10000001-01100100-
// 00011001-11011010-11100010-00110111-01111010-11010101-01110111-00110111-
// 10101001-01111001-10001111-00011001-01101111-00010010-01110111-10101001-
// 11100010-00110111-01101001-11000110-01110111-10111111-00110111-11101000-
// 00010011-11100010-10101001-11101000

console.log(`Cipher Ascii:${cipher.toAscii()}`);

// Cipher Ascii:
// ©ÚÚdn dÚâ7zÕw7©y ow©â7iÆw¿7èâ©è

const plain = Cryptography.Decrypt(cipher, keys);

console.log(`Plain Text Decrypted:${plain}`);

//Plain Text Decrypted:
// Hello,World but encrypted with s-des
```

In this example, we generate a 10-bit secret key from the secret array, encrypt the string using the generated keys, and then decrypt the cipher using the same keys. The output of this example will be the cipher bits, the cipher ASCII representation, and the plain text decrypted from the cipher.
