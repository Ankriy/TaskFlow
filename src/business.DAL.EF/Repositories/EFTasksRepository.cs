using business.Logic.DataContracts.Repositories;
using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.DataContracts.Repositories.Notes;
using business.Logic.DataContracts.Repositories.Task;
using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;
using business.Logic.Domain.Models.Tasks;
using Microsoft.EntityFrameworkCore;

namespace business.DAL.EF.Repositories
{
    public class EFTasksRepository : ITasksRepository, IRepository<Logic.Domain.Models.Tasks.Task>
    {
        private readonly PostgreeContext _context;
        public EFTasksRepository(PostgreeContext context)
        {
            _context = context;
        }
        public int Count()
        {
            return _context.Tasks.Count();
        }

        public int Count(int userid)
        {
            return _context.Tasks.Where(x => x.UserId == userid).Count();
        }

        public Logic.Domain.Models.Tasks.Task Create(Logic.Domain.Models.Tasks.Task item)
        {
            _context.Tasks.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        
        public ICollection<Logic.Domain.Models.Tasks.Task> GetByUserId(int userid)
        {
            IQueryable<Logic.Domain.Models.Tasks.Task> query = _context.Tasks;
            
            var tasks = query
                .OrderBy(p => p.Id)
                .Where(x => x.UserId == userid)
                .ToList();

            return tasks;
        }

        public Logic.Domain.Models.Tasks.Task? Get(int id)
        {
            return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        

        public void Update(Logic.Domain.Models.Tasks.Task item)
        {
            _context.Tasks.Update(item);
            _context.SaveChanges();
        }

        
    }
}
