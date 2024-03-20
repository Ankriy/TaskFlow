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
        private readonly ClientService _clientService;

        public HomeController(ILogger<HomeController> logger, ClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        public IActionResult Tab()
        {
            return View();
        }


    }
}