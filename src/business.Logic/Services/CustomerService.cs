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
        public int GetAllCount(int userid)
        {
            return _clientRepository.Count(userid);
        }
        
        public int AddClient(Customer client)
        {
            var newClient = new Customer()
            {
                Id = client.Id,
                UserId = client.UserId,
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
                UserId = client.UserId,
                Name = client.Name,
                Surname = client.Surname,
                Middlename = client.Middlename,
                Phone = client.Phone,
                Email = client.Email
            };
        }
        public object EditClient(Customer clientUpdate)
        {
            var client = new Customer()
            {
                Id = clientUpdate.Id,
                UserId = clientUpdate.UserId,
                Name = clientUpdate.Name,
                Surname = clientUpdate.Surname,
                Middlename = clientUpdate.Middlename,
                Phone = clientUpdate.Phone,
                Email = clientUpdate.Email
            };
            _clientRepository.Update(client);
            return clientUpdate.Id;
        }
    }
}