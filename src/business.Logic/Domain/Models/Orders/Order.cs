using System.ComponentModel.DataAnnotations.Schema;
using business.Logic.Domain.Models.Users;
using business.Logic.Domain.Models.Customers;
using System.ComponentModel.DataAnnotations;

namespace business.Logic.Domain.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public AspNetUsers? User { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime? OrderDate { get; set; }
        [Required]
        public int OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public OrderStatus? OrderStatus { get; set; }
        [Required]
        public int PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        public OrderPaymentMethod? PaymentMethod { get; set; }
        public int? CostPrice { get; set; }
        public int? TotalCost { get; set; }
        public string? Description { get; set; }
        public string? CancellationReason { get; set; }
        public DateTime? CancellationDate { get; set; }

    }
}
