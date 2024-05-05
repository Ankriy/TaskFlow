using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.DataContracts.Repositories.Notes;
using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;

namespace business.Logic.Services
{
    public class DashboardService
    {
        private INoteRepository _noteRepository;
        private ITagRepository _tagRepository;
        public DashboardService(INoteRepository noteRepository,
            ITagRepository tagRepository)
        {
            _noteRepository = noteRepository;
            _tagRepository = tagRepository;
        }

    }
}