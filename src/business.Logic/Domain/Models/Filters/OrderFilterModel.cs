namespace business.Logic.Domain.Models.Filters
{
    public class OrderFilterModel
    {
        public int? OrderStatus { get; set; }
        public int? minTotalCost { get; set; }
        public int? maxTotalCost { get; set; }
        public DateTime? minOrderDate { get; set; }
        public DateTime? maxOrderDate { get; set; }
    }
}
