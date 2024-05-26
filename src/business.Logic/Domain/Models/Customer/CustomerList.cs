namespace business.Logic.Domain.Models.Customers
{
    public class CustomerList
    {
        public List<Customer> Customers { get; set; }
        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
