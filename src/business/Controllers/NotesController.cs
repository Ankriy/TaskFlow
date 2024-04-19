using business.Application.Web.Models.Customers;
using business.Application.Web.Models.Notes;
using business.Application.Web.Services.Identity;
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
        private readonly NoteService _noteService;
        private readonly CurrentUserService _currentUserService;

        public NotesController(ILogger<NotesController> logger, 
                               NoteService noteService,
                               CurrentUserService currentUserService)
        {
            _logger = logger;
            _noteService = noteService;
            _currentUserService = currentUserService;
        }

        

        [HttpGet]
        public IActionResult Notes()
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            var customerList = _noteService.GetNoteList((int)currentUser.Id);
            var tags = _noteService.GetTags();
            var model = new NoteListViewModel(customerList, tags);
            
            return View(model);
        }
        [HttpPost]
        public IActionResult Notes(int a)
        {
            return View();
        }


    }
}