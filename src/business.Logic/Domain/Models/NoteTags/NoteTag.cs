using System.ComponentModel.DataAnnotations.Schema;
using business.Logic.Domain.Models.Users;

namespace business.Logic.Domain.Models.NoteTags
{
    public class NoteTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public AspNetUsers? User { get; set; }
        public int Order { get; set; }

    }
}
