using business.Application.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace business.Application.Web.Services.Identity;

public interface ICurrentUserService
{
    string CreateToken(ApplicationUser user, List<IdentityRole<long>> role);
}