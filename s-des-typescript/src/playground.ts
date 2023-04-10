import Cryptography from "./class/Cryptography";
import { BinaryUtil } from "./class/BinaryUtil";

const string = "google";
const secret = [1, 0, 0, 0, 1, 0, 1, 1, 1, 0];

const keys = Cryptography.GenerateKey(secret);
const cipher = Cryptography.Encryption(string, keys);
console.log(cipher.toString());
console.log(BinaryUtil.toAscii(cipher));
