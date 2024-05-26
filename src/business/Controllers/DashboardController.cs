using business.Application.Web.Services.Identity;
using business.Logic.Domain.Models.Orders.Enums;
using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace business.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly DashboardService _dashboardService;
        private readonly OrderService _orderService;
        private readonly CurrentUserService _currentUserService;

        public DashboardController(ILogger<DashboardController> logger, 
            DashboardService dashboardService,
            OrderService orderService,
            CurrentUserService currentUserService)
        {
            _logger = logger;
            _dashboardService = dashboardService;
            _orderService = orderService;
            _currentUserService = currentUserService;
        }

        

        [HttpGet]
        public IActionResult Dashboard([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Dashboard()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult GetDataForChart()
        {
            var data = new List<int> { 10, 12, 9, 15, 13 };
            return Json(data);
        }
        [HttpGet]
        public IActionResult profit(DateTime startDate, DateTime endDate)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            if(endDate == DateTime.MinValue)
                endDate = DateTime.MaxValue;
            var orders = _orderService
                .GetOrderList(0, 99999, (int)currentUser.Id, null).Orders
                .Where(c => (c.OrderDate >= startDate && c.OrderDate <= endDate && (c.OrderStatusId == (int)OrderStatusType.Завершён || c.OrderStatusId == (int)OrderStatusType.Доставлен)))
                    .Select(c => new { value = c.TotalCost - c.CostPrice, label = c.OrderDate, date = c.OrderDate });
            return Json(orders);
        }
        [HttpGet]
        public IActionResult expenses()
        {
            var data = new List<int> { 1, 20, 9, 15, 20 };
            return Json(data);
        }
        [HttpGet]
        public IActionResult income()
        {
            var data = new List<int> { 3, 9, 12, 15, 20 };
            return Json(data);
        }
        [HttpGet]
        public IActionResult orders()
        {
            var data = new List<int> { 1, 20, 1, 20, 1 };
            return Json(data);
        }

    }
}