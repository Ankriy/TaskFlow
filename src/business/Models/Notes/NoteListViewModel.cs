

using business.Logic.Domain.Models.Customer;

namespace business.Application.Web.Models.Notes
{
    public class NoteListViewModel
    {
        public List<NoteShortViewModel> Customers { get; set; }

        public NoteListViewModel()
        {
            Customers = new List<NoteShortViewModel>();
        }

        public NoteListViewModel(CustomerList list)
        {
            Customers = new List<NoteShortViewModel>();
            foreach (Customer customer in list.Customers)
            {
                Customers.Add(new NoteShortViewModel(customer));
            }
        }
    }
}
