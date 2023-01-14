using Microsoft.AspNetCore.Mvc;
using s_des.Class;
using s_des.Entity;

namespace api.Controllers;

[Route("[controller]")]
[ApiController]
public class MainController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string p, string k)
    {
        if(p!.Length != 8) return BadRequest("Key must be 8 bits long");
        if (k!.Length != 10) return BadRequest("Key must be 10 bits long");
        return Ok(Main.MakeWithString(p, k));
    }
}