using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace business.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ClientService _clientService;

        public OrderController(ILogger<OrderController> logger, ClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }


        [HttpGet]
        public IActionResult TableOrders([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            if (size == 0)
                size = 10;
            var skip = page * size;
            var listUsers = _clientService.GetClientList(1, 1);
            return View();


        }
        [HttpPost]
        public IActionResult TableOrders()
        {
            var listUsers = _clientService.GetClientList(1, 1);
            //return PartialView("Tabs/client");
            return View();
        }


    }
}