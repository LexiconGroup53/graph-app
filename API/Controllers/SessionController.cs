using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/session")]
public class SessionController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public IActionResult Login(LoginDTO login)
    {
        CookieOptions options = new CookieOptions();
        options.Expires = DateTime.Now.AddMinutes(1);
        Response.Cookies.Append("GraphApp", "77", options);
        return Ok("Logged in");
    }

    [HttpGet]
    [Route("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("GraphApp");
        return Ok("Logged out");
    }
}