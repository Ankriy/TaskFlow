using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace business.Controllers
{
    public class TabController : Controller
    {
        private readonly ILogger<TabController> _logger;
        private readonly CustomerService _clientService;

        public TabController(ILogger<TabController> logger, CustomerService clientService)
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