using Microsoft.AspNetCore.Mvc;
using Task = business.Logic.Domain.Models.Tasks.Task;

namespace business.Application.Web.Models.Tasks
{
    public class TaskShortViewModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public TaskShortViewModel() { }

        public TaskShortViewModel(Task note)
        {
            Id = note.Id;
            UserId = note.UserId;
            Name = note.Name;
            Description = note.Description;
            Color = note.Color;
        }
    }
}
