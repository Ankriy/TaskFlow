

using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Notes;

namespace business.Application.Web.Models.Notes
{
    public class NoteListViewModel
    {
        public List<NoteShortViewModel> Notes { get; set; }

        public NoteListViewModel()
        {
            Notes = new List<NoteShortViewModel>();
        }

        public NoteListViewModel(NoteList list)
        {
            Notes = new List<NoteShortViewModel>();
            foreach (Note note in list.Notes)
            {
                Notes.Add(new NoteShortViewModel(note));
            }
        }
    }
}
