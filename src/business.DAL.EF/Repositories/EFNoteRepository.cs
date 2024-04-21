using business.Logic.DataContracts.Repositories;
using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.DataContracts.Repositories.Notes;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;
using Microsoft.EntityFrameworkCore;

namespace business.DAL.EF.Repositories
{
    public class EFNoteRepository : INoteRepository, IRepository<Note>
    {
        private readonly PostgreeContext _context;
        public EFNoteRepository(PostgreeContext context)
        {
            _context = context;
        }
        public int Count()
        {
            return _context.Notes.Count();
        }

        public int Count(int userid)
        {
            return _context.Notes.Where(x => x.UserId == userid).Count();
        }

        public Note Create(Note item)
        {
            _context.Notes.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var customer = _context.Notes.FirstOrDefault(t => t.Id == id);

            if (customer != null)
            {
                _context.Notes.Remove(customer);
                _context.SaveChanges();
            }
        }

        
        public ICollection<Note> GetByUserId(int userid)
        {
            IQueryable<Note> query = _context.Notes;
            
            var users = query
                .OrderBy(p => p.Id)
                .Where(x => x.UserId == userid)
                .Include(p => p.NoteTags)
                .ToList();

            return users;
        }

        public Note? Get(int id)
        {
            return _context.Notes.FirstOrDefault(x => x.Id == id);
        }

        

        public void Update(Note item)
        {
            _context.Notes.Update(item);
            _context.SaveChanges();
        }

        
    }
}
