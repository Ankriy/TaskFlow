using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Logic.DataContracts.Repositories
{
    public interface IRepository<T>
    {
        public T Get(int id);
        public T Create(T item);
        public void Update(T item);
        public void Delete(int id);
        int Count();
        int Count(int clientid);
    }
}
