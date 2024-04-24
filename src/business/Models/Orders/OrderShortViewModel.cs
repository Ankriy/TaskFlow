using business.Logic.Domain.Models.Customer;
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
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentMethodId { get; set; }
        public int DeliveryCost { get; set; }
        public int TotalCost { get; set; }
        public string Description { get; set; }
        public string CancellationReason { get; set; }
        public DateTime CancellationDate { get; set; }
        public OrderShortViewModel() { }

        public OrderShortViewModel(Order order)
        {
            Id = order.Id;
            CancellationDate = order.CancellationDate;
            CancellationReason = order.CancellationReason;
            CustomerId = order.CustomerId;
            DeliveryCost = order.DeliveryCost;
            Description = order.Description;
            OrderDate = order.OrderDate;
            OrderStatusId = order.OrderStatusId;
            PaymentMethodId = order.PaymentMethodId;
            TotalCost = order.TotalCost;
            UserId = order.UserId;
        }
    }
}
