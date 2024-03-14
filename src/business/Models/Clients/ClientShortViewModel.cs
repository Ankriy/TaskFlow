using business.Logic.Domain.Models.Client;

namespace business.Models.Clients
{
    public class ClientShortViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ClientShortViewModel() { }

        public ClientShortViewModel(Client user)
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
