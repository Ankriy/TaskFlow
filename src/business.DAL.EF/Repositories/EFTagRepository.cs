using business.Logic.DataContracts.Repositories;
using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.DataContracts.Repositories.Notes;
using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;
using business.Logic.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace business.DAL.EF.Repositories
{
    public class EFTagRepository : ITagRepository, IRepository<NoteTag>
    {
        private readonly PostgreeContext _context;
        public EFTagRepository(PostgreeContext context)
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

        public NoteTag Create(NoteTag item)
        {
            _context.NoteTags.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var tag = _context.NoteTags.FirstOrDefault(t => t.Id == id);

            if (tag != null)
            {
                _context.NoteTags.Remove(tag);
                _context.SaveChanges();
            }
        }

        public NoteTag Get(int id)
        {
            var tag = _context.NoteTags.FirstOrDefault(x => x.Id == id);
            return tag;
        }

        public NoteTag GetByTextAndUserId(string text, int userId)
        {
            IQueryable<NoteTag> query = _context.NoteTags;
            var Tabs = query
                .Where(x => x.UserId == userId && x.Name == text)
                .FirstOrDefault();
            return Tabs;
        }

        public ICollection<NoteTag> GetTags(int userid)
        {
            IQueryable<NoteTag> query = _context.NoteTags;
            var Tabs = query
                .Where(x => x.UserId == userid)
                .OrderBy(x => x.Order)
                .ToList();
            return Tabs;
        }

        public void Update(NoteTag item)
        {
            _context.NoteTags.Update(item);
            _context.SaveChanges();
        }
    }
}
