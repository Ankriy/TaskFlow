using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Logic.Domain.Models.Users
{
    public class AspNetUsers
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
