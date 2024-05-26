

using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;
using business.Logic.Domain.Models.Tasks;
using Task = business.Logic.Domain.Models.Tasks.Task;

namespace business.Application.Web.Models.Tasks
{
    public class TaskListViewModel
    {
        public List<TaskShortViewModel> Tasks { get; set; }
        public TaskShortViewModel? CurrentTask {  get; set; }
        public TaskListViewModel()
        {
            Tasks = new List<TaskShortViewModel>();
        }

        public TaskListViewModel(TaskList list)
        {
            Tasks = new List<TaskShortViewModel>();
            foreach (Task note in list.Tasks)
            {
                Tasks.Add(new TaskShortViewModel(note));
            }
        }
    }
}
