using business.Logic.Domain.Models.Notes;

namespace business.Logic.DataContracts.Repositories.Notes
{
    public interface INoteRepository : IRepository<Note>
    {
        ICollection<Note> GetByUserId(int userid);
    }
}
