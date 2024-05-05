

using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Orders;

namespace business.Application.Web.Models.Orders
{
    public class OrderListViewModel
    {
        public List<OrderShortViewModel> Orders { get; set; }

        public EditOrderViewModel OrderForEdit { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public bool CanBack { get; set; }
        public bool CanForward { get; set; }

        public OrderListViewModel()
        {
            Orders = new List<OrderShortViewModel>();
        }

        public OrderListViewModel(OrderList list, int page, int size)
        {
            Orders = new List<OrderShortViewModel>();
            foreach (Order order in list.Orders)
            {
                Orders.Add(new OrderShortViewModel(order));
            }

            TotalCount = list.TotalCount;
            Page = page;
            PageSize = size;

            CanBack = Page > 0;
            CanForward = (Page + 1) * PageSize < TotalCount;
            CanBack = Page > 0;
        }
    }
}
