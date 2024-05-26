using business.Logic.Domain.Models.Customers;

namespace business.Logic.DataContracts.Repositories.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        ICollection<Customer> Get(string search, int skip, int take, int userid);
    }
}
