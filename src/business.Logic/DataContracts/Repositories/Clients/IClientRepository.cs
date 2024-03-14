using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business.Logic.Domain.Models.Client;

namespace business.Logic.DataContracts.Repositories.Clients
{
    public interface IClientRepository : IRepository<Client>
    {
        ICollection<Client> Get(string search, int skip, int take);
    }
}
