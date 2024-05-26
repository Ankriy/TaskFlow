using business.Application.Web.Models.Tasks;
using business.Application.Web.Services.Identity;
using business.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace business.Controllers
{
    public class TasksController : Controller
    {
        private readonly ILogger<TasksController> _logger;
        private readonly TaskService _taskService;
        private readonly CurrentUserService _currentUserService;

        public TasksController(ILogger<TasksController> logger,
                               TaskService taskService,
                               CurrentUserService currentUserService)
        {
            _logger = logger;
            _taskService = taskService;
            _currentUserService = currentUserService;
        }
        [HttpGet]
        public IActionResult Tasks(int id)
        {
            var currentUser = _currentUserService.GetUser();
            if (currentUser == null)
                return BadRequest("Bad credentials");
            var customerList = _taskService.GetTaskList((int)currentUser.Id);
            var model = new TaskListViewModel(customerList);
            if(id > 0)
                model.CurrentTask = model.Tasks.Where(x => x.Id == id).First();
            
            return View(model);
        }
        
    }
}