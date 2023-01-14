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
    public SuperDic Get(string plain, string key)
    {
        var plainBitArray = plain!.Select(i => Convert.ToInt32(i) - 48).ToArray();
        var secretBitArray = key!.Select(i => Convert.ToInt32(i) - 48).ToArray();

        // key generation
        var keys = KeyGenerator.Generate(secretBitArray);
        var keyGenRes = keys.Results;

        // encryption
        var cipher = Transformer.Encrypt(new BitBuffer(plainBitArray), keys.Exit);
        var cipherRes = cipher.Results;

        // decryption
        var decrypt = Transformer.Decrypt(cipher.Exit, keys.Exit);
        var decryptRes = decrypt.Results;

        // format to show as key values
        var final = keyGenRes.Concat(cipherRes).Concat(decryptRes);
        return final;
    }
}