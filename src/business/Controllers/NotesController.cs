using business.Application.Web.Models.Customers;
using business.Application.Web.Models.Notes;
using business.Application.Web.Services.Identity;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;
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
            var tags = _noteService.GetTags((int)currentUser.Id);
            var model = new NoteListViewModel(customerList, tags);
            
            return View(model);
        }
        [HttpPost]
        public IActionResult AddNewNote(Note note)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            note.UserId = (int)currentUser.Id;
            if(note.TagId == 0)
            {
                note.TagId = 1;
            }
            _noteService.AddNote(note);
            return Json(new { success = true, noteId = note.Id, subTagId = note.TagId });
        }
        [HttpPost]
        public IActionResult EditNote(Note note )
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            note.UserId = (int)currentUser.Id;
            if (note.TagId == 0)
            {
                note.TagId = 1;
            }
            _noteService.EditNote(note);
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult DeleteNote(Note note)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            _noteService.DeleteNote(note.Id);
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult AddNewTag(NoteTag tag)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            tag.UserId = (int)currentUser.Id;
            _noteService.AddTag(tag);
            return Json(new { success = true, tagId = tag.Id });
        }
        [HttpPost]
        public IActionResult EditTag(NoteTag tag)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            tag.UserId = (int)currentUser.Id;
            _noteService.EditTag(tag);
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult DeleteTag(NoteTag tag)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            _noteService.DeleteTag(tag.Id);
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult EditSubTag(int noteId, string NameSubTag)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            var note = _noteService.GetNote(noteId);
            if (note == null)
                return Json(new { success = false });
            var tag = _noteService.SearchTagByTextAndUserId(NameSubTag, (int)currentUser.Id);
            if (tag == null || tag.Id == 0)
                return Json(new { success = false });
            note.TagId = tag.Id;

            _noteService.EditNote(note);
            return Json(new { success = true, subTagId = note.TagId });
        }

    }
}