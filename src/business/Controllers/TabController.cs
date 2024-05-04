using Microsoft.AspNetCore.Mvc;

namespace business.Controllers
{
    public class TabController : Controller
    {
        private readonly ILogger<TabController> _logger;

        public TabController(ILogger<TabController> logger)
        {
            _logger = logger;
        }

        public IActionResult Tab()
        {
            return View();
        }


    }
}