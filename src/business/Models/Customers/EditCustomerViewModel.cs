using business.Logic.Domain.Models.Customers;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace business.Application.Web.Models.Customers
{
    public class EditCustomerViewModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public EditCustomerViewModel() { }

        public EditCustomerViewModel(Customer user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            Middlename = user.Middlename;
            Email = user.Email;
            Phone = user.Phone;
        }
    }
}
