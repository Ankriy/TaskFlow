using business.Application.Web.Services.Identity;
using business.Logic.Domain.Models.FeedBack;
using business.Logic.Domain.Models.Notes;
using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace business.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FeedBackService _feedBackService;
        private readonly CurrentUserService _currentUserService;

        public HomeController(ILogger<HomeController> logger, 
            FeedBackService feedBackService, 
            CurrentUserService currentUserService)
        {
            _logger = logger;
            _feedBackService = feedBackService;
            _currentUserService = currentUserService;
        }
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FeedBack(string feedback)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            _feedBackService.AddFeedBack(feedback, (int)currentUser.Id);
            return Ok(new { });
        }
    }
}