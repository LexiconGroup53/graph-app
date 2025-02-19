using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class GraphDbContext : IdentityDbContext
{
    public GraphDbContext(DbContextOptions<GraphDbContext> options) : base(options)
    {
        
    }

    public DbSet<UserPreference> UserPreferences { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
}