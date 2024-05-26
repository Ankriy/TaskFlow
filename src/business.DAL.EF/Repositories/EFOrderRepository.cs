using business.Logic.DataContracts.Repositories;
using business.Logic.DataContracts.Repositories.Orders;
using business.Logic.Domain.Models.Filters;
using business.Logic.Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace business.DAL.EF.Repositories
{
    public class EFOrderRepository : IOrderRepository, IRepository<Order>
    {
        private readonly PostgreeContext _context;
        public EFOrderRepository(PostgreeContext context)
        {
            _context = context;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(int userid)
        {
            return _context.Customers.Where(x => x.UserId == userid).Count();
        }

        public Order Create(Order item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(t => t.Id == id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public Order Get(int id)
        {
            var tag = _context.Orders.FirstOrDefault(x => x.Id == id);
            return tag;
        }

        public ICollection<Order> Get(string search, int skip, int take, int userid, OrderFilterModel? filter)
        {
            IQueryable<Order> query = _context.Orders;

            if (filter != null)
            {
                if (filter.OrderStatus.HasValue)
                {
                    query = query.Where(o => o.OrderStatusId == filter.OrderStatus);
                }

                if (filter.minTotalCost.HasValue)
                {
                    query = query.Where(o => o.TotalCost >= filter.minTotalCost);
                }

                if (filter.maxTotalCost.HasValue)
                {
                    query = query.Where(o => o.TotalCost <= filter.maxTotalCost);
                }

                if (filter.minOrderDate.HasValue)
                {
                    query = query.Where(o => o.OrderDate >= filter.minOrderDate);
                }

                if (filter.maxOrderDate.HasValue)
                {
                    query = query.Where(o => o.OrderDate <= filter.maxOrderDate);
                }
            }

            var users = query
                .OrderBy(p => p.Id)
                .Include(o => o.PaymentMethod)
                .Include(o => o.OrderStatus)
                .Include(o => o.Customer)
                .Include(o => o.User)
                .Where(x => x.UserId == userid)
                .Skip(skip)
                .Take(take)
                .ToList();

            return users;
        }

        public void Update(Order item)
        {
            _context.Orders.Update(item);
            _context.SaveChanges();
        }
    }
}
