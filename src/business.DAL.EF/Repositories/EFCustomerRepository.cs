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
            return _context.Customers.Count();
        }

        public int Count(int userid)
        {
            return _context.Customers.Where(x => x.UserId == userid).Count();
        }

        public Customer Create(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(t => t.Id == id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public ICollection<Customer> Get(string search, int skip, int take, int userid)
        {
            IQueryable<Customer> query = _context.Customers;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(x => x.Name.StartsWith(search) || x.Surname.StartsWith(search));

            var users = query
                .OrderBy(p => p.Id)
                .Where(x => x.UserId == userid)
                .Skip(skip)
                .Take(take)
                .ToList();

            return users;
        }

        public Customer? Get(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == id);
        }

        

        public void Update(Customer item)
        {
            _context.Customers.Update(item);
            _context.SaveChanges();
        }
        
    }
}
