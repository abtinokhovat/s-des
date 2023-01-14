using s_des.Class;
using Formatting = Newtonsoft.Json.Formatting;

//int[] secretBitArray = {1,0,1,0,1,0,1,0,1,0};
//int[] plainBits = {1,0,0,1,0,1,1,0};

Console.WriteLine("Insert 8-bit Plain Text");
//var plain = Console.ReadLine();
var plain = "10010110";
if(plain!.Length != 8) throw new Exception("Key must be 8 bits long");
Console.WriteLine("\n");

Console.WriteLine("Insert 10-bit Key");
//var key = Console.ReadLine();
var key = "1001000100";
if(key!.Length != 10) throw new Exception("Key must be 10 bits long");
Console.WriteLine("\n");

var res = Main.MakeWithString(plain, key);

Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(res, (Formatting) System.Xml.Formatting.Indented));