using business.Logic.DataContracts.Repositories.Notes;

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