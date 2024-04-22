using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;

namespace business.Logic.DataContracts.Repositories.Notes
{
    public interface ITagRepository : IRepository<NoteTag>
    {
        ICollection<NoteTag> GetTags(int userid);
        NoteTag GetByTextAndUserId(string text, int userId);
    }
}
