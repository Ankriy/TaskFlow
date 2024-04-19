using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.DataContracts.Repositories.Notes;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;

namespace business.Logic.Services
{
    public class NoteService
    {
        private INoteRepository _noteRepository;
        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public int GetAllCount(int userid)
        {
            return _noteRepository.Count(userid);
        }
        
        public int AddNote(Note note)
        {
            _noteRepository.Create(note);
            return note.Id;
        }
        public Note GetNote(int id)
        {
            
            var client = _noteRepository.Get(id);
            return client;
        }
        public NoteList GetNoteList(int userId)
        {
            var count = _noteRepository.Count(userId);
            var result = new NoteList();

            result.Notes = _noteRepository
                .GetByUserId(userId)
                .Select(x => new Note()
                {
                    Id = x.Id,
                    Text = x.Text,
                    TagId = x.TagId,
                    NoteTags = x.NoteTags,
                    Color = x.Color
                }).ToList();
            return result;
        }
        public object EditNote(Note note)
        {
            _noteRepository.Update(note);
            return note.Id;
        }
        public void DeleteNote(int idCustomer)
        {
            _noteRepository.Delete(idCustomer);
        }
        public List<NoteTag>  GetTags()
        {
            return _noteRepository.GetTags(1).ToList();
        }
    }
}