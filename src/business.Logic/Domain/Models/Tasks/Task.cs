using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business.Logic.Domain.Models.Users;
using business.Logic.Domain.Models.NoteTags;

namespace business.Logic.Domain.Models.Tasks
{
    public class Task
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public AspNetUsers? User { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }

    }
}
