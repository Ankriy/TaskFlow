using business.Application.Web.Models.Notes;
using business.Application.Web.Services.Identity;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;
using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace business.Controllers
{
    public class TasksController : Controller
    {
        private readonly ILogger<NotesController> _logger;
        private readonly NoteService _noteService;
        private readonly CurrentUserService _currentUserService;

        public TasksController(ILogger<NotesController> logger, 
                               NoteService noteService,
                               CurrentUserService currentUserService)
        {
            _logger = logger;
            _noteService = noteService;
            _currentUserService = currentUserService;
        }
        [HttpGet]
        public IActionResult Tasks()
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            var customerList = _noteService.GetNoteList((int)currentUser.Id);
            var tags = _noteService.GetTags((int)currentUser.Id);
            var model = new NoteListViewModel(customerList, tags);
            
            return View(model);
        }
        
    }
}