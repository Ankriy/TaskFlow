using business.Logic.Domain.Models.Authorization;
using business.Logic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace business.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly CustomerService _clientService;


        public AuthorizationController(ILogger<AuthorizationController> logger, 
            CustomerService clientService)
        {
            _logger = logger;
            _clientService = clientService;
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
        // Action для входа
        [HttpPost("login")]
        public IActionResult Login([FromForm] Login model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Логика входа
            // ...
            return RedirectToAction("Dashboard", "Dashboard");
        }

        // Action для регистрации
        [HttpPost("register")]
        public IActionResult Register([FromForm] Register model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Логика регистрации
            // ...
            return RedirectToAction("Authorization");
        }

        // Action для сброса пароля
        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromForm] ForgotPassword model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Логика сброса пароля
            // ...
            return RedirectToAction("Authorization");
        }








    }

}
