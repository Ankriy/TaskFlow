using Microsoft.AspNetCore.Identity;

namespace business.Application.Web.Data.Entities;

public class ApplicationUser : IdentityUser<long>
{
    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string? Photo { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}