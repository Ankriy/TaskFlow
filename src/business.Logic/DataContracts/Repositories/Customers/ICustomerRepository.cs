using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business.Logic.Domain.Models.Customer;

namespace business.Logic.DataContracts.Repositories.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        ICollection<Customer> Get(string search, int skip, int take);
    }
}
