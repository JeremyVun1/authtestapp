using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.AspNetCore.Authorization;

namespace authtestapp.Controllers;

[ApiController]
[Route("")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello World!");
    }

    [Authorize]
    [HttpGet]
    [Route("secret")]
    public IActionResult Secret()
    {
        return Ok(HttpContext.User);
    }
}
