using business.Application.Web.Data;
using business.Application.Web.Data.Entities;
using business.Application.Web.Extensions;
using business.Application.Web.Models.Identity;
using business.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace business.Application.Web.Middleware
{
    public class TokenExpirationMiddleware
    {
        private readonly RequestDelegate _next;
        public TokenExpirationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, 
            IConfiguration _configuration, 
            UserManager<ApplicationUser> _userManager,
            IHttpContextAccessor httpContextAccessor, DataContext _dataContext )
        {
            if (context.Request.Path.Value == "/" || 
                context.Request.Path.Value == "/authenticate" || 
                context.Request.Path.Value == "/register")
            {
                await _next(context);
                return;
            }
            var accessToken = context.Request.Cookies[".AspNetCore.Application.Id"];
            var accessTokenExpiryTime = context.Request.Cookies[".AspNetCore.Application.IdExpiryTime"];
            var refreshToken = context.Request.Cookies[".AspNetCore.Application.IdRefreshToken"];
            var RefreshTokenExpiryTime = context.Request.Cookies[".AspNetCore.Application.IdRefreshTokenExpiryTime"];
            
            if (accessToken != null && refreshToken != null)
            {
                var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);
                if (principal != null)
                {
                    var i = new TokenModel{ AccessToken = accessToken, RefreshToken = refreshToken};

                    //context.Response.Redirect("/Authorization/refresh-token", true);
                    var username = principal.Identity!.Name;
                    var user = await _userManager.FindByNameAsync(username!);
                    if (user != null && DateTime.Parse(accessTokenExpiryTime!) > DateTime.UtcNow)
                    {
                        await _next(context);
                        return;
                    }
                    if (user != null && user.RefreshToken == refreshToken && user.RefreshTokenExpiryTime > DateTime.UtcNow)
                    {
                        var tokenModel = new TokenModel { AccessToken = accessToken, RefreshToken = refreshToken };
                        var refresh = new AuthorizationController(null!, null!, _dataContext, _userManager, _configuration);
                        refresh.ControllerContext.HttpContext = httpContextAccessor.HttpContext!;
                        await refresh.RefreshToken(tokenModel).ConfigureAwait(false);
                        await _next(context);
                        return;
                    }
                    //Переводит на окно авторизации если истек и accesstoken и refreshtoken
                    context.Response.Redirect("/");
                }
            }
            context.Response.Redirect("/");
            //context.Response.StatusCode = 401; // Unauthorized
            //await context.Response.WriteAsync("Unauthorized");

        }
    }
}
