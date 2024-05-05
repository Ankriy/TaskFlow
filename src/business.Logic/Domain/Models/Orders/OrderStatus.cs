using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business.Logic.Domain.Models.Users;
using business.Logic.Domain.Models.NoteTags;
using System.Data.SqlTypes;

namespace business.Logic.Domain.Models.Orders
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }

    }
}
