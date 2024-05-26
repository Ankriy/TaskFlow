using business.Logic.Domain.Models.Customers;

namespace business.Logic.DataContracts.Repositories.Customers
{
    public interface IAuthorizationRepository : IRepository<Customer>
    {
        ICollection<Customer> Get(string search, int skip, int take);
    }
}
