using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Notes;

namespace business.Logic.DataContracts.Repositories.Notes
{
    public interface INoteRepository : IRepository<Note>
    {
        ICollection<Note> GetByUserId(int userid);
    }
}
