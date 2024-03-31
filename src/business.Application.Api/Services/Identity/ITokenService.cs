using business.Application.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace business.Application.Api.Services.Identity;

public interface ITokenService
{
    string CreateToken(ApplicationUser user, List<IdentityRole<long>> role);
}