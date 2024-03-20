using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace business.Controllers
{
    public class NotesController : Controller
    {
        private readonly ILogger<NotesController> _logger;
        private readonly CustomerService _clientService;

        public NotesController(ILogger<NotesController> logger, CustomerService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        

        [HttpGet]
        public IActionResult Notes([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            
            return View();


        }
        [HttpPost]
        public IActionResult Notes()
        {
            return View();
        }


    }
}