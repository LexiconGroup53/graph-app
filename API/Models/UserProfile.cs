namespace API.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public UserPreference UserPreference { get; set; }
}