using business.Logic.Domain.Models.NoteTags;

namespace business.Logic.DataContracts.Repositories.Notes
{
    public interface ITagRepository : IRepository<NoteTag>
    {
        ICollection<NoteTag> GetTags(int userid);
        NoteTag GetByTextAndUserId(string text, int userId);
    }
}
