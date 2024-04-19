using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Notes;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace business.Application.Web.Models.Notes
{
    public class NoteShortViewModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        public string Text { get; set; }
        public string? TagName { get; set; }
        public string Color { get; set; }
        public NoteShortViewModel() { }

        public NoteShortViewModel(Note note)
        {
            Id = note.Id;
            Text = note.Text;
            TagName = note.NoteTags.Name;
            Color = note.Color;
        }
    }
}
