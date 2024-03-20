using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace business.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly CustomerService _clientService;

        public DashboardController(ILogger<DashboardController> logger, CustomerService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        

        [HttpGet]
        public IActionResult Dashboard([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            
            return View();


        }
        [HttpPost]
        public IActionResult Dashboard()
        {
            
            return View();
        }


    }
}