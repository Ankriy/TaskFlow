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
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public User? User { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentMethodId { get; set; }
        public int DeliveryCost { get; set; }
        public int TotalCost { get; set; }
        public string Description { get; set; }
        public string CancellationReason { get; set; }
        public DateTime CancellationDate { get; set; }

    }
}
