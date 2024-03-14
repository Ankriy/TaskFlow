using business.Logic.DataContracts.Repositories;
using business.Logic.DataContracts.Repositories.Clients;
using business.Logic.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.DAL.EF.Repositories
{
    public class EFClientRepository : IClientRepository, IRepository<Client>
    {
        private readonly PostgreeContext _context;
        public EFClientRepository(PostgreeContext context)
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

        public Client Create(Client item)
        {
            _context.Client.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Client> Get(string search, int skip, int take)
        {
            IQueryable<Client> query = _context.Client;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(x => x.Name.StartsWith(search) || x.Surname.StartsWith(search));

            var users = query
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take)
                .ToList();

            return users;
        }

        public Client? Get(int id)
        {
            return _context.Client.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Client item)
        {
            _context.Client.Update(item);
            _context.SaveChanges();
        }
        
    }
}
