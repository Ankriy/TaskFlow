using System.ComponentModel.DataAnnotations.Schema;
using business.Logic.Domain.Models.Users;

namespace business.Logic.Domain.Models.FeedBack
{
    public class FeedBack
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public AspNetUsers? User { get; set; }
        public string Text { get; set; }

    }
}
