using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.DataContracts.Repositories.Notes;
using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;

namespace business.Logic.Services
{
    public class NoteService
    {
        private INoteRepository _noteRepository;
        private ITagRepository _tagRepository;
        public NoteService(INoteRepository noteRepository,
            ITagRepository tagRepository)
        {
            _noteRepository = noteRepository;
            _tagRepository = tagRepository;
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
        public void DeleteNote(int idNote)
        {
            _noteRepository.Delete(idNote);
        }
        public List<NoteTag>  GetTags(int UserId)
        {
            return _tagRepository.GetTags(UserId).ToList();
        }
        public NoteTag GetTag(int tagId)
        {
            return _tagRepository.Get(tagId);
        }
        public int AddTag(NoteTag tag)
        {
            var Tag = _tagRepository.Create(tag);
            return Tag.Id;
        }
        public void EditTag(NoteTag tag)
        {
            _tagRepository.Update(tag);
        }
        public void DeleteTag(int tagid)
        {
            _tagRepository.Delete(tagid);
        }
        public NoteTag SearchTagByTextAndUserId(string text, int userId)
        {
            return _tagRepository.GetByTextAndUserId(text, userId);
        }
    }
}