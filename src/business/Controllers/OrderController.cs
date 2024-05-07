using business.Application.Web.Models.Orders;
using business.Application.Web.Services.Identity;
using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Filters;
using business.Logic.Domain.Models.Orders;
using business.Logic.Domain.Models.Orders.Enums;
using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Drawing;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace business.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderService _orderService;
        private readonly CurrentUserService _currentUserService;
        private readonly CustomerListService _customerListService;

        public OrderController(ILogger<OrderController> logger, 
            OrderService orderService,
            CurrentUserService currentUserService,
            CustomerListService customerListService)
        {
            _logger = logger;
            _orderService = orderService;
            _currentUserService = currentUserService;
            _customerListService = customerListService;
        }


        [HttpGet]
        public IActionResult TableOrders([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size, int id, OrderFilterModel filter)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            if (size == 0)
                size = 10;
            var skip = page * size;
            var orderList = _orderService.GetOrderList(skip, size, (int)currentUser.Id, filter);
            var model = new OrderListViewModel(orderList, page, size, filter);
            if (id > 0)
            {
                var data = orderList.Orders.Find(x => x.Id == id);
                var editCustomer = new EditOrderViewModel(data);

                model.OrderForEdit = editCustomer;

            }
            if (id == -1)
            {
                model.OrderForEdit = new EditOrderViewModel();
                model.OrderForEdit.OrderStatus = new OrderStatus();
                model.OrderForEdit.PaymentMethod = new OrderPaymentMethod();
                model.OrderForEdit.Customer = new Customer();
                ViewData["Name"] = "Добавить заказ";
                return View(model);
            }
            ViewData["Name"] = "Информация о заказе";
            return View(model);


        }
        [HttpPost]
        public IActionResult TableOrders()
        {
            return RedirectToAction("TableOrders");
        }

        [HttpGet]
        public JsonResult SearchCustomer(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var currentUser = _currentUserService.GetUser();
                var customers = _customerListService.GetCustomerList(0, 10000000, (int)currentUser.Id);
                var filteredCustomers = customers.Customers
                    .Where(c => (c.Surname + " " + c.Name + " " + c.Middlename).ToLower().Contains(search.ToLower())) // Assuming 'Name' property
                    .Select(c => new {id =c.Id, text = c.Surname + " " + c.Name + " " + c.Middlename }).Take(3);
                return Json(filteredCustomers);
            }
            return Json(new {});
        }
        [HttpPost]
        public IActionResult EditOrder(Order order)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            order.UserId = (int)currentUser.Id;
            if (!order.OrderStatus.Status.IsNullOrEmpty())
            {
                order.OrderStatusId = OrderStatusHelper.GetIdFromName(order.OrderStatus.Status.Replace(" ", ""));
                order.OrderStatus.Id = OrderStatusHelper.GetIdFromName(order.OrderStatus.Status.Replace(" ", ""));
            }
            else
            {
                order.OrderStatusId = (int)OrderStatusType.Новый;
                order.OrderStatus.Id = (int)OrderStatusType.Новый;
                order.OrderStatus.Status = OrderStatusType.Новый.ToString();
            }
                
            if (!order.PaymentMethod.Method.IsNullOrEmpty())
            {
                order.PaymentMethodId = PaymentMethodHelper.GetIdFromName(order.PaymentMethod.Method);
                order.PaymentMethod.Id = PaymentMethodHelper.GetIdFromName(order.PaymentMethod.Method);
            }
            else
            {
                order.PaymentMethodId = (int)PaymentMethodType.Неуказано;
                order.PaymentMethod.Id = (int)PaymentMethodType.Неуказано;
                order.PaymentMethod.Method = PaymentMethodType.Неуказано.ToString();
                order.OrderDate = DateTime.Today;
            }
            if(order.OrderStatusId == (int)OrderStatusType.Отменён)
                order.CancellationDate = DateTime.Today;

            _orderService.EditOrder(order);

            return RedirectToAction("TableOrders");
        }
        [HttpPost]
        public IActionResult DeleteOrder(int id)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            _orderService.DeleteOrder(id);
            return RedirectToAction("TableOrders");
        }

    }
}