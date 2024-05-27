using business.Logic.DataContracts.Repositories;
using business.Logic.DataContracts.Repositories.Task;
using business.Logic.Domain.Models.Tasks;
using Task = business.Logic.Domain.Models.Tasks.Task;

namespace business.DAL.EF.Repositories
{
    public class EFSubTaskRepository : ISubTaskRepository, IRepository<SubTask>
    {
        private readonly PostgreeContext _context;
        public EFSubTaskRepository(PostgreeContext context)
        {
            _context = context;
        }
        public int Count()
        {
            return _context.SubTasks.Count();
        }

        public int Count(int taskid)
        {
            return _context.SubTasks.Where(x => x.TaskId == taskid).Count();
        }

        public SubTask Create(SubTask item)
        {
            _context.SubTasks.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var task = _context.SubTasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                _context.SubTasks.Remove(task);
                _context.SaveChanges();
            }
        }
        
        public ICollection<SubTask> GetByTaskId(int taskid)
        {
            IQueryable<SubTask> query = _context.SubTasks;
            
            var tasks = query
                .OrderBy(p => p.Id)
                .Where(x => x.TaskId == taskid)
                .ToList();

            return tasks;
        }

        public SubTask? Get(int id)
        {
            return _context.SubTasks.FirstOrDefault(x => x.Id == id);
        }

        public void Update(SubTask item)
        {
            _context.SubTasks.Update(item);
            _context.SaveChanges();
        }

        
    }
}
