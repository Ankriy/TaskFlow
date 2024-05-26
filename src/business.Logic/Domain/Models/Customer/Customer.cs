using System.ComponentModel.DataAnnotations.Schema;
using business.Logic.Domain.Models.Users;

namespace business.Logic.Domain.Models.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public AspNetUsers? User { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
    }
}
