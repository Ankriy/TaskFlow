using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.User;

namespace business.Logic.DataContracts.Repositories.Customers
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByID(int id);
    }
}
