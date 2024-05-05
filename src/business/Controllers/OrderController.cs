using business.Application.Web.Models.Orders;
using business.Application.Web.Services.Identity;
using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace business.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderService _orderService;
        private readonly CurrentUserService _currentUserService;

        public OrderController(ILogger<OrderController> logger, 
            OrderService orderService,
            CurrentUserService currentUserService)
        {
            _logger = logger;
            _orderService = orderService;
            _currentUserService = currentUserService;
        }


        [HttpGet]
        public IActionResult TableOrders([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size, int id)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            if (size == 0)
                size = 10;
            var skip = page * size;
            var orderList = _orderService.GetOrderList(skip, size, (int)currentUser.Id);
            var model = new OrderListViewModel(orderList, page, size);
            if (id > 0)
            {
                var data = orderList.Orders.Find(x => x.Id == id);
                var editCustomer = new EditOrderViewModel(data);

                model.OrderForEdit = editCustomer;

            }
            return View(model);


        }
        [HttpPost]
        public IActionResult TableOrders()
        {
            return RedirectToAction("TableOrders");
        }


    }
}