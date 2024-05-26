using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business.Logic.Domain.Models.Users;
using business.Logic.Domain.Models.NoteTags;
using business.Logic.Domain.Models.Notes;

namespace business.Logic.Domain.Models.Tasks
{
    public class TaskList
    {
        public List<Task> Tasks { get; set; }

    }
}
