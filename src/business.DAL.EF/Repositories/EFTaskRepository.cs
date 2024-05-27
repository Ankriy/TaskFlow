using business.Logic.DataContracts.Repositories;
using business.Logic.DataContracts.Repositories.Task;
using Task = business.Logic.Domain.Models.Tasks.Task;

namespace business.DAL.EF.Repositories
{
    public class EFTaskRepository : ITaskRepository, IRepository<Task>
    {
        private readonly PostgreeContext _context;
        public EFTaskRepository(PostgreeContext context)
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

        public Task Create(Task item)
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
        
        public ICollection<Task> GetByUserId(int userid)
        {
            IQueryable<Task> query = _context.Tasks;
            
            var tasks = query
                .OrderBy(p => p.Id)
                .Where(x => x.UserId == userid)
                .ToList();

            return tasks;
        }

        public Task? Get(int id)
        {
            return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Task item)
        {
            _context.Tasks.Update(item);
            _context.SaveChanges();
        }

        
    }
}
