using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ix.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult PingPong() => Ok("Pong");
}
