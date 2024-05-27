using System.ComponentModel.DataAnnotations.Schema;
using business.Logic.Domain.Models.Users;

namespace business.Logic.Domain.Models.Tasks
{
    public class SubTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        [NotMapped]
        public Task? Task { get; set; }
        public string Name { get; set; }
        public bool? IsDone { get; set; }
        public string? Date { get; set; }
        public string? Priority { get; set; }

    }
}
