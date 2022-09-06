using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;

namespace wms.Controllers;

[Route("hello")]
public class HelloController : IController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Hello()
    {
         return Ok("Hello!");
    }
}