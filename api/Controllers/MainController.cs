using Microsoft.AspNetCore.Mvc;
using s_des.Class;
using s_des.Entity;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MainController : ControllerBase
{
    // GET: api/Main
    [HttpGet]
    public Root Get(string plain, string key)
    {
        var plainBitArray = plain!.Select(i => Convert.ToInt32(i) - 48).ToArray();
        var secretBitArray = key!.Select(i => Convert.ToInt32(i) - 48).ToArray();

        // key generation
        var keys = KeyGenerator.Generate(secretBitArray);
        var keyGenRes = keys.Item2;

        // encryption
        var cipher = Transformer.Encrypt(new BitBuffer(plainBitArray), keys.Item1);
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