using business.Application.Web.Data.Entities;
using business.Application.Web.Models.Customers;
using business.Application.Web.Models.Identity;
using business.Application.Web.Models.Settings;
using business.Application.Web.Services.Identity;
using business.Logic.Domain.Models.Users;
using business.Logic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace business.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly CurrentUserService _currentUserService;
        private readonly UserManager<ApplicationUser> _userManager;

        public SettingsController(ILogger<SettingsController> logger,
            CurrentUserService currentUserService,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<AuthResponse>> Settings(int pag)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            
            var user = await _userManager.FindByIdAsync(currentUser.Id.ToString());
            if (user == null)
                return BadRequest("Bad credentials");
            var model = new SettingViewModel(user);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult<AuthResponse>> Settings(ApplicationUser user, string currentPassword, string newPassword)
        {
            var currentuser = await _userManager.FindByIdAsync(user.Id.ToString());
            if(currentPassword != null && newPassword != null && currentuser != null)
                await _userManager.ChangePasswordAsync(currentuser, currentPassword, newPassword);

            currentuser.FirstName = user.FirstName;
            currentuser.LastName = user.LastName;
            currentuser.MiddleName = user.MiddleName;
            currentuser.UserName = user.UserName;
            currentuser.Email = user.Email;
            //_userManager.ChangeEmailAsync();



            await _userManager.UpdateAsync(currentuser);
            var model = new SettingViewModel(user);
            return View(model);
        }


    }
}