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
        private readonly ClientService _clientService;

        public DashboardController(ILogger<DashboardController> logger, ClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        

        [HttpGet]
        public IActionResult Dashboard([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            if (size == 0)
                size = 10;
            var skip = page * size;
            var listUsers = _clientService.GetClientList(1, 1);
            return View();


        }
        [HttpPost]
        public IActionResult Dashboard()
        {
            var listUsers = _clientService.GetClientList(1, 1);
            //return PartialView("Tabs/client");
            return View();
        }


    }
}