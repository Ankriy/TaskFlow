using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Logic.Domain.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public byte[]? Photo { get; set; }

    }
}
