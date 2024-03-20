using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace business.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly CustomerListService _customerListService;

        public CustomerController(ILogger<CustomerController> logger, CustomerListService clientService)
        {
            _logger = logger;
            _customerListService = clientService;
        }

        [HttpGet]
        public IActionResult TableCustomers([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            if (size == 0)
                size = 10;
            var skip = page * size;
            var listUsers = _customerListService.GetClientList(1, 1);
            return View();


        }
        [HttpPost]
        public IActionResult TableCustomers(string name1, string name2)
        {
            var listUsers = _customerListService.GetClientList(1, 1);
            //return PartialView("Tabs/client");
            return View();
        }


    }
}