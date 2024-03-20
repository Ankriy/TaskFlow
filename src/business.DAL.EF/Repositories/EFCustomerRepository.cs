using business.Logic.DataContracts.Repositories;
using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.Domain.Models.Customer;

namespace business.DAL.EF.Repositories
{
    public class EFCustomerRepository : ICustomerRepository, IRepository<Customer>
    {
        private readonly PostgreeContext _context;
        public EFCustomerRepository(PostgreeContext context)
        {
            _context = context;
        }
        public int Count()
        {
            return _context.Client.Count();
        }

        public int Count(int userid)
        {
            throw new NotImplementedException();
        }

        public Customer Create(Customer item)
        {
            _context.Client.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> Get(string search, int skip, int take)
        {
            IQueryable<Customer> query = _context.Client;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(x => x.Name.StartsWith(search) || x.Surname.StartsWith(search));

            var users = query
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take)
                .ToList();

            return users;
        }

        public Customer? Get(int id)
        {
            return _context.Client.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Customer item)
        {
            _context.Client.Update(item);
            _context.SaveChanges();
        }
        
    }
}
