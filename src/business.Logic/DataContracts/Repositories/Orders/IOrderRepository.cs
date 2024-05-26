using business.Logic.Domain.Models.Filters;
using business.Logic.Domain.Models.Orders;

namespace business.Logic.DataContracts.Repositories.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        ICollection<Order> Get(string search, int skip, int take, int userid, OrderFilterModel? filter);
    }
}
