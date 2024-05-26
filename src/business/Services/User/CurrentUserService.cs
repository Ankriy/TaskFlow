using business.Application.Web.Data.Entities;
using business.Application.Web.Extensions;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace business.Application.Web.Services.Identity;

public class CurrentUserService : ICurrentUserService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;

    private ApplicationUser _User;
    public CurrentUserService(IHttpContextAccessor httpContextAccessor,
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration)
    {
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
        _userManager = userManager;
    }

    public string CreateToken(ApplicationUser user, List<IdentityRole<long>> roles)
    {
        var token = user
            .CreateClaims(roles)
            .CreateJwtToken(_configuration);
        var tokenHandler = new JwtSecurityTokenHandler();
        
        return tokenHandler.WriteToken(token);
    }
    public ApplicationUser? GetUser()
    {
        if (_User == null)
            SetUser();

        return _User;
    }
    //private void SetUser()
    //{
    //    _User = null;
    //    if (_httpContextAccessor.HttpContext == null)
    //        return;

    //    var claim = _httpContextAccessor.HttpContext.User.Claims
    //        .FirstOrDefault(x => x.Type == "Id");

    //    realUserId = 0;
    //        _User = _userManager.FindByIdAsync(realUserId.ToString());
    //    //SetRolesFromHttpContext();
    //}
    private async void SetUser()
    {
        _User = null;
        if (_httpContextAccessor.HttpContext == null)
            return;

        var accessToken = _httpContextAccessor.HttpContext.Request.Cookies[".AspNetCore.Application.Id"];
        
        var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);

        if (principal == null)
        {
            return;
        }
        var username = principal.Identity!.Name;
        _User = _userManager.FindByNameAsync(username!).Result!;
    }
}