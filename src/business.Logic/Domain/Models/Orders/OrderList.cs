namespace business.Logic.Domain.Models.Orders
{
    public class OrderList
    {
        public List<Order> Orders { get; set; }
        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
