using business.Logic.Domain.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace business.Application.Web.Models.Notes
{
    public class NoteShortViewModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Tag { get; set; }
        public string Color { get; set; }
        public NoteShortViewModel() { }

        public NoteShortViewModel(Customer user)
        {
            Id = user.Id;
            Name = user.Name;
            Text = user.Surname;
            Middlename = user.Middlename;
            Email = user.Email;
            Phone = user.Phone;
        }
    }
}
