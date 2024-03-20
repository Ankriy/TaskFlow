using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace business.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly CustomerService _clientService;

        public SettingsController(ILogger<SettingsController> logger, CustomerService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        

        [HttpGet]
        public IActionResult TableCustomers([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            
            return View();


        }
        [HttpPost]
        public IActionResult TableCustomers()
        {
            
            return View();
        }


    }
}