using business.Application.Web.Models.Customers;
using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;

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
            var customerList = _customerListService.GetClientList(skip, size);
            var model = new CustomerListViewModel(customerList, page, size);
            return View(model);


        }
        [HttpPost]
        public IActionResult TableCustomers(string name1, string name2, int selectedOption)
        {
            return RedirectToAction("TableCustomers");
        }


    }
}