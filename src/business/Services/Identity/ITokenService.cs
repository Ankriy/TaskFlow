using business.Application.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace business.Application.Web.Services.Identity;

public interface ITokenService
{
    string CreateToken(ApplicationUser user, List<IdentityRole<long>> role);
}