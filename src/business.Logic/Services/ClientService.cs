using business.Logic.DataContracts.Repositories.Clients;
using business.Logic.Domain.Models.Client;

namespace business.Logic.Services
{
    public class ClientService
    {
        private IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public int GetAllCount()
        {
            return _clientRepository.Count();
        }
        public List<Client> GetClientList(int skip, int take)
        {
            var users = _clientRepository.Get("", skip, take);
            var list = users.Select(x => new Client()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Middlename = x.Middlename,
                Email = x.Email,
                Phone = x.Phone
            }).ToList();
            return list;
        }

        public int AddClient(Client client)
        {
            var newClient = new Client()
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email
            };
            _clientRepository.Create(newClient);
            return newClient.Id;
        }
        public Client GetClient(int id)
        {
            
            var client = _clientRepository.Get(id);
            return new Client()
            {
                Id = id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email
            };
        }
        public object EditClient(Client clientUpdate)
        {
            var client = new Client()
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