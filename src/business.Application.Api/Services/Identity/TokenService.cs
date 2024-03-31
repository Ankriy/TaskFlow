
using business.Application.Api.Data.Entities;
using business.Application.Api.Extensions;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace business.Application.Api.Services.Identity;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateToken(ApplicationUser user, List<IdentityRole<long>> roles)
    {
        var token = user
            .CreateClaims(roles)
            .CreateJwtToken(_configuration);
        var tokenHandler = new JwtSecurityTokenHandler();
        
        return tokenHandler.WriteToken(token);
    }
}