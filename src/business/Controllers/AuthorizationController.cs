using business.Application.Web.Data;
using business.Application.Web.Data.Entities;
using business.Application.Web.Extensions;
using business.Application.Web.Models.Identity;
using business.Application.Web.Services.Identity;
using business.Logic.Domain.Models.Authorization;
using business.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace business.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly ILogger<AuthorizationController> _logger;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthorizationController(ILogger<AuthorizationController> logger,
            ITokenService tokenService,
            DataContext context,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _logger = logger;

            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }



        [HttpGet]
        public IActionResult Authorization([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            return View();


        }
        [HttpPost]
        public IActionResult Authorization()
        {
            return View();
        }



        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromForm] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var managedUser = await _userManager.FindByEmailAsync(request.Email);

            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
            if (user is null)
                return Unauthorized();

            var roleIds = await _context.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
            var roles = _context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();

            var accessToken = _tokenService.CreateToken(user, roles);
            var accessTokenExpiryTime = DateTime.UtcNow.AddMinutes(_configuration.GetSection("Jwt:Expire").Get<int>());
            user.RefreshToken = _configuration.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_configuration.GetSection("Jwt:TokenValidityInMinutes").Get<int>());
            await _context.SaveChangesAsync();

            // Создаем ответ, который будет содержать токены
            var response = new AuthResponse
            {
                Username = user.UserName!,
                Email = user.Email!,
                Token = accessToken,
                RefreshToken = user.RefreshToken
            };

            // Добавляем заголовки к ответу
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", accessToken);
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.IdExpiryTime", accessTokenExpiryTime.ToString());
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.IdRefreshToken", user.RefreshToken);
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.IdRefreshTokenExpiryTime", user.RefreshTokenExpiryTime.ToString());
            
            
            return RedirectToAction("Dashboard", "Dashboard"/*, response*/);
            //return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register([FromForm] RegisterRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(request);

            var user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                UserName = request.Email
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            if (!result.Succeeded) return BadRequest(request);

            var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (findUser == null) throw new Exception($"User {request.Email} not found");

            await _userManager.AddToRoleAsync(findUser, RoleConsts.Member);


            return await Authenticate(new AuthRequest
            {
                Email = request.Email,
                Password = request.Password
            });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromQuery]TokenModel? tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }

            var accessToken = tokenModel.AccessToken;
            var refreshToken = tokenModel.RefreshToken;
            var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);

            if (principal == null)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var username = principal.Identity!.Name;
            var user = await _userManager.FindByNameAsync(username!);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var newAccessToken = _configuration.CreateToken(principal.Claims.ToList());
            var newRefreshToken = _configuration.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_configuration.GetSection("Jwt:TokenValidityInMinutes").Get<int>());
            var accessTokenExpiryTime = DateTime.UtcNow.AddMinutes(_configuration.GetSection("Jwt:Expire").Get<int>());
            await _userManager.UpdateAsync(user);
            var i = new JwtSecurityTokenHandler().WriteToken(newAccessToken);
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", new JwtSecurityTokenHandler().WriteToken(newAccessToken));
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.IdExpiryTime", accessTokenExpiryTime.ToString());
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.IdRefreshToken", newRefreshToken);
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.IdRefreshTokenExpiryTime", user.RefreshTokenExpiryTime.ToString());

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                accessTokenExpiryTime = accessTokenExpiryTime,
                refreshToken = newRefreshToken,
                RefreshTokenExpiryTime = user.RefreshTokenExpiryTime
            });
        }

        [Authorize]
        [HttpPost]
        [Route("revoke/{username}")]
        public async Task<IActionResult> Revoke(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return BadRequest("Invalid user name");

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);

            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("revoke-all")]
        public async Task<IActionResult> RevokeAll()
        {
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }

            return Ok();
        }





        ////Action для входа
        //[HttpPost("login")]
        //public IActionResult Login([FromForm] AuthRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // Логика входа
        //    // ...
        //    return RedirectToAction("Dashboard", "Dashboard");
        //}

        //// Action для регистрации
        //[HttpPost("register")]
        //public IActionResult Register([FromForm] Register model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // Логика регистрации
        //    // ...
        //    return RedirectToAction("Authorization");
        //}

        //// Action для сброса пароля
        //[HttpPost("forgot-password")]
        //public IActionResult ForgotPassword([FromForm] ForgotPassword model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // Логика сброса пароля
        //    // ...
        //    return RedirectToAction("Authorization");
        //}



    }

}
