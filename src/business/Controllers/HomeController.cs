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

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public ActionResult dashboard()
        {
            return PartialView("Tabs/dashboard");
        }
        [HttpGet]
        public ActionResult client(int page, int size)
        {
            if (size == 0)
                size = 10;
            var skip = page * size;
            var listUsers = _clientService.GetClientList(1,1);
            return PartialView("Tabs/client");
            //return View();
        }
        [HttpPost]
        public ActionResult client()
        {
            var listUsers = _clientService.GetClientList(1, 1);
            //return PartialView("Tabs/client");
            return View();
        }
        [HttpGet]
        public ActionResult order()
        {
            return PartialView("Tabs/order");
        }
        [HttpGet]
        public ActionResult notes()
        {
            return PartialView("Tabs/notes");
        }
        public ActionResult settings()
        {
            return PartialView("Tabs/settings");
        }

    }
}