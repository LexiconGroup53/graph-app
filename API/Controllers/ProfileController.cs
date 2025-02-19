using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("profile")]
public class ProfileController : ControllerBase
{
    private readonly UserManager<AppUser> _manager;
    private readonly GraphDbContext _context;

    public ProfileController(UserManager<AppUser> manager, GraphDbContext context)
    {
        _manager = manager;
        _context = context;
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(LoginDTO profile)
    {
        var newUser = new AppUser { UserName = profile.Email, Email = profile.Email, AlternativeEmail = profile.Email };
        var result = await _manager.CreateAsync(newUser, profile.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        
        UserProfile newProfile = new UserProfile
        {
            AppUserId = newUser.Id,
            UserPreference = new UserPreference()
        };

        _context.UserProfiles.Add(newProfile);
        await _context.SaveChangesAsync();
        
        return Ok();
    }
}