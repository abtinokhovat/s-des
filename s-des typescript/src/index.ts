import BitBuffer from "./class/BitBuffer";
import { KeyGenerator } from "./class/KeyGenetor";

const secretBitArray = [1, 0, 1, 0, 1, 0, 1, 0, 1, 0];
const [key, root] = KeyGenerator.generate(secretBitArray);
console.log(root);
