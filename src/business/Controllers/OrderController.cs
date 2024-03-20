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
        private readonly CustomerService _clientService;

        public OrderController(ILogger<OrderController> logger, CustomerService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }


        [HttpGet]
        public IActionResult TableOrders([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            
            return View();


        }
        [HttpPost]
        public IActionResult TableOrders()
        {
            
            return View();
        }


    }
}