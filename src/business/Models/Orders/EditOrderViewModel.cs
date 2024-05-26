using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Orders;
using business.Logic.Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace business.Application.Web.Models.Orders
{
    public class EditOrderViewModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        public AspNetUsers? User { get; set; }
        public Customer? Customer { get; set; }
        public DateTime? OrderDate { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public OrderPaymentMethod? PaymentMethod { get; set; }
        public int? CostPrice { get; set; }
        public int? TotalCost { get; set; }
        public string? Description { get; set; }
        public string? CancellationReason { get; set; }
        public DateTime? CancellationDate { get; set; }
        public EditOrderViewModel() { }

        public EditOrderViewModel(Order order)
        {
            Id = order.Id;
            CancellationDate = order.CancellationDate;
            CancellationReason = order.CancellationReason;
            Customer = order.Customer;
            CostPrice = order.CostPrice;
            Description = order.Description;
            OrderDate = order.OrderDate;
            OrderStatus = order.OrderStatus;
            PaymentMethod = order.PaymentMethod;
            TotalCost = order.TotalCost;
            User = order.User;
        }
    }
}
