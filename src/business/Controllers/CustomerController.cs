﻿using business.Application.Web.Models.Customers;
using business.Application.Web.Services.Identity;
using business.Logic.Domain.Models.Customers;
using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace business.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly CustomerListService _customerListService;
        private readonly CustomerService _customerService;
        private readonly CurrentUserService _currentUserService;

        public CustomerController(
            ILogger<CustomerController> logger, 
            CustomerListService customerListService,
            CustomerService customerService,
            CurrentUserService currentUserService)
        {
            _logger = logger;
            _customerListService = customerListService;
            _customerService = customerService;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public IActionResult TableCustomers([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size, int id)
        {
            var currentUser = _currentUserService.GetUser();
            if(currentUser == null)
                return BadRequest("Bad credentials");

            if (size == 0)
                size = 10;
            var skip = page * size;
            var customerList = _customerListService.GetCustomerList(skip, size,(int)currentUser.Id);
            var model = new CustomerListViewModel(customerList, page, size);
            if(id > 0)
            {
                var data = _customerService.GetCustomer(id);
                var editCustomer = new EditCustomerViewModel(data);

                model.CustomerForEdit = editCustomer;
                
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult TableCustomers()
        {
            return RedirectToAction("TableCustomers");
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            customer.UserId = (int)currentUser.Id;
            _customerService.AddCustomer(customer);
            return RedirectToAction("TableCustomers");
        }
        [HttpGet]
        public IActionResult EditCustomer(int id, CustomerListViewModel model)
        {
            var data = _customerService.GetCustomer(id);
            var editCustomer = new EditCustomerViewModel(data);
            model.CustomerForEdit = editCustomer;
            return View("TableCustomers", model);
            //return View(model);
        }
        [HttpPost]
        public IActionResult EditCustomer(Customer customer)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            customer.UserId = (int)currentUser.Id;
            _customerService.EditCustomer(customer);
            return RedirectToAction("TableCustomers");
        }
        [HttpPost]
        public IActionResult DeleteCustomer(int id)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            _customerService.DeleteCustomer(id);
            return RedirectToAction("TableCustomers");
        }

    }
}