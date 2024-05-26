
using business.Logic.Domain.Models.FeedBack;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.Tasks;

namespace business.Logic.DataContracts.Repositories.Task
{
    public interface ITasksRepository : IRepository<Domain.Models.Tasks.Task>
    {
        ICollection<Domain.Models.Tasks.Task> GetByUserId(int userid);
    }
}
