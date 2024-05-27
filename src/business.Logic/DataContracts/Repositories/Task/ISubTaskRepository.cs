using business.Logic.Domain.Models.Tasks;

namespace business.Logic.DataContracts.Repositories.Task
{
    public interface ISubTaskRepository : IRepository<SubTask>
    {
        ICollection<SubTask> GetByTaskId(int userid);
    }
}
