using business.Logic.DataContracts.Repositories;
using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Users;

namespace business.DAL.EF.Repositories
{
    public class EFUserRepository : IUserRepository, IRepository<User>
    {
        private readonly PostgreeContext _context;
        public EFUserRepository(PostgreeContext context)
        {
            _context = context;
        }
        public int Count()
        {
            return _context.Customer.Count();
        }

        public int Count(int userid)
        {
            throw new NotImplementedException();
        }

        public User Create(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User? Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User? GetByID(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User item)
        {
            _context.Users.Update(item);
            _context.SaveChanges();
        }
        
    }
}
