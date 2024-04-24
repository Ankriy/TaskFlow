using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;
using business.Logic.Domain.Models.Orders;

namespace business.Logic.DataContracts.Repositories.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        ICollection<Order> Get(string search, int skip, int take, int userid);
    }
}
