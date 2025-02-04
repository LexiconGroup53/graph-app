using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/session")]
public class SessionController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public IActionResult Login(string userId)
    {
        CookieOptions options = new CookieOptions();
        options.Expires = DateTime.Now.AddMinutes(1);
        Response.Cookies.Append("GraphApp", userId, options);
        return Ok();
    }

    [HttpGet]
    [Route("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("GraphApp");
        return Ok();
    }
}