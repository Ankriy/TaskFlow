using business.Logic.DataContracts.Repositories;
using business.Logic.DataContracts.Repositories.FeedBacks;
using business.Logic.Domain.Models.FeedBack;

namespace business.DAL.EF.Repositories
{
    public class EFFeedBackRepository : IFeedBackRepository, IRepository<FeedBack>
    {
        private readonly PostgreeContext _context;
        public EFFeedBackRepository(PostgreeContext context)
        {
            _context = context;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(int userid)
        {
            throw new NotImplementedException();
        }

        public FeedBack Create(FeedBack item)
        {
            _context.FeedBacks.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FeedBack Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(FeedBack item)
        {
            throw new NotImplementedException();
        }
    }
}
