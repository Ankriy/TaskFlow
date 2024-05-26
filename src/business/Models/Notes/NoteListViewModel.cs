using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;

namespace business.Application.Web.Models.Notes
{
    public class NoteListViewModel
    {
        public List<NoteShortViewModel> Notes { get; set; }
        public List<NoteTag> Tags { get; set; }
        public NoteListViewModel()
        {
            Notes = new List<NoteShortViewModel>();
        }

        public NoteListViewModel(NoteList list, List<NoteTag> tags)
        {
            Notes = new List<NoteShortViewModel>();
            foreach (Note note in list.Notes)
            {
                Notes.Add(new NoteShortViewModel(note));
            }
            Tags = tags;
        }
    }
}
