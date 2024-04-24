using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace business.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly DashboardService _dashboardService;

        public DashboardController(ILogger<DashboardController> logger, DashboardService dashboardService)
        {
            _logger = logger;
            _dashboardService = dashboardService;
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
        public IActionResult profit()
        {
            var data = new List<int> { 10, 12, 9, 15, 13 };
            return Json(data);
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