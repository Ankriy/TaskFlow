using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace business.Application.Web.Models.Orders
{
    public class OrderShortViewModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        public int UserId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime? OrderDate { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public OrderPaymentMethod? PaymentMethod { get; set; }
        public int? DeliveryCost { get; set; }
        public int? TotalCost { get; set; }
        public string? Description { get; set; }
        public string? CancellationReason { get; set; }
        public DateTime? CancellationDate { get; set; }
        public OrderShortViewModel() { }

        public OrderShortViewModel(Order order)
        {
            Id = order.Id;
            CancellationDate = order.CancellationDate;
            CancellationReason = order.CancellationReason;
            Customer = order.Customer;
            DeliveryCost = order.DeliveryCost;
            Description = order.Description;
            OrderDate = order.OrderDate;
            OrderStatus = order.OrderStatus;
            PaymentMethod = order.PaymentMethod;
            TotalCost = order.TotalCost;
            UserId = order.UserId;
        }
    }
}
