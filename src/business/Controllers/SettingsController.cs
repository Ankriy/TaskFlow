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
using Microsoft.IdentityModel.Tokens;
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
        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int Id, IFormFile photo)
        {
            var currentuser = await _userManager.FindByIdAsync(Id.ToString());


            if (photo == null || photo.Length == 0)
            {
                return BadRequest("No image uploaded.");
            }
            if (!string.IsNullOrEmpty(currentuser.Photo))
            {
                var path = currentuser.Photo.Split('/');
                var oldPhotoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path[1], path[2]);
                if (System.IO.File.Exists(oldPhotoPath))
                {
                    System.IO.File.Delete(oldPhotoPath);
                }
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "profilePhotos", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            // Return the URL or path to the saved image
            var imageUrl = Url.Content("~/profilePhotos/" + fileName);
            currentuser.Photo = imageUrl;
            await _userManager.UpdateAsync(currentuser);
            return Ok(new { imageUrl });
        }
        [HttpPost]
        public async Task<IActionResult> DeletePhoto(int Id)
        {
            var currentuser = await _userManager.FindByIdAsync(Id.ToString());

            if (!string.IsNullOrEmpty(currentuser.Photo))
            {
                var path = currentuser.Photo.Split('/');
                var oldPhotoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path[1], path[2]);
                if (System.IO.File.Exists(oldPhotoPath))
                {
                    System.IO.File.Delete(oldPhotoPath);
                }
            }
            currentuser.Photo = null;
            await _userManager.UpdateAsync(currentuser);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> HeaderBarData()
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser != null)
                if(currentUser.UserName == null)
                    return BadRequest("Bad credentials");
            var username = currentUser!.UserName!;
            var imageUrl = currentUser.Photo;
            return Ok(new { username, imageUrl }) ;
        }
        

    }
}