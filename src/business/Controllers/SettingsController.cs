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
        public ActionResult client(int page, int size)
        {
            if (size == 0)
                size = 10;
            var skip = page * size;
            var listUsers = _clientService.GetClientList(1,1);
            return View();
            //return View();
        }
        [HttpPost]
        public ActionResult client(string name1, string name2)
        {
            var listUsers = _clientService.GetClientList(1, 1);
            //return PartialView("Tabs/client");
            return View();
        }

        [HttpGet]
        public IActionResult TableCustomers([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            if (size == 0)
                size = 10;
            var skip = page * size;
            var listUsers = _clientService.GetClientList(1, 1);
            return View();


        }
        [HttpPost]
        public IActionResult TableCustomers()
        {
            var listUsers = _clientService.GetClientList(1, 1);
            //return PartialView("Tabs/client");
            return View();
        }


    }
}