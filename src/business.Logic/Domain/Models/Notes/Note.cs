using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business.Logic.Domain.Models.Users;
using business.Logic.Domain.Models.NoteTags;

namespace business.Logic.Domain.Models.Notes
{
    public class Note
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public User? User { get; set; }
        public string Text { get; set; }
        public int TagId { get; set; }
        public NoteTag? NoteTags { get; set; }
        public string? Color { get; set; }

    }
}
