using business.Application.Web.Data.Entities;
using business.Application.Web.Extensions;
using business.Logic.Domain.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace business.Application.Web.Services.Identity;

public class CurrentUserService : ICurrentUserService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private User _User;
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string CreateToken(ApplicationUser user, List<IdentityRole<long>> roles)
    {
        var token = user
            .CreateClaims(roles)
            .CreateJwtToken(_configuration);
        var tokenHandler = new JwtSecurityTokenHandler();
        
        return tokenHandler.WriteToken(token);
    }
    public User GetUser()
    {
        if (_User == null)
            SetUser();

        return _User;
    }
    private void SetUser()
    {
        _User = null;
        if (_httpContextAccessor.HttpContext == null)
            return;

        var claim = _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(x => x.Type == "Id");

        if (!int.TryParse(claim?.Value, out int realUserId))
            return;

        _User = _userRepository.GetByID(realUserId);
        SetRolesFromHttpContext();
    }
}