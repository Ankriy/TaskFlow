using business.Logic.Domain.Models.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using Task = business.Logic.Domain.Models.Tasks.Task;

namespace business.Application.Web.Models.Tasks
{
    public class SubTaskShortViewModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public bool? IsDone { get; set; }
        public string? Date { get; set; }
        public string? Priority { get; set; }
        public SubTaskShortViewModel() { }

        public SubTaskShortViewModel(SubTask subtask)
        {
            Id = subtask.Id;
            TaskId = subtask.TaskId;
            Name = subtask.Name;
            IsDone = subtask.IsDone;
            Date = subtask.Date;
            Priority = subtask.Priority;
        }
    }
}
