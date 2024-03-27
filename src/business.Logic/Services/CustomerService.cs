using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.Domain.Models.Customer;

namespace business.Logic.Services
{
    public class CustomerService
    {
        private ICustomerRepository _clientRepository;
        public CustomerService(ICustomerRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public int GetAllCount()
        {
            return _clientRepository.Count();
        }
        
        public int AddClient(Customer client)
        {
            var newClient = new Customer()
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Middlename = client.Middlename,
                Phone = client.Phone,
                Email = client.Email
            };
            _clientRepository.Create(newClient);
            return newClient.Id;
        }
        public Customer GetClient(int id)
        {
            
            var client = _clientRepository.Get(id);
            return new Customer()
            {
                Id = id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email
            };
        }
        public object EditClient(Customer clientUpdate)
        {
            var client = new Customer()
            {
                Id = clientUpdate.Id,
                Name = clientUpdate.Name,
                Surname = clientUpdate.Surname,
                Email = clientUpdate.Email
            };
            _clientRepository.Update(client);
            return clientUpdate.Id;
        }
    }
}