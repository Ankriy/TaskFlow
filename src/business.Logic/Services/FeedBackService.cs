using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.DataContracts.Repositories.FeedBacks;
using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.FeedBack;
using System.Net;

namespace business.Logic.Services
{
    public class FeedBackService
    {
        private IFeedBackRepository _clientRepository;
        public FeedBackService(IFeedBackRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        
        public int AddFeedBack(string Text, int userId)
        {
            var result = new FeedBack
            {
                Text = Text,
                UserId = userId
            };

            _clientRepository.Create(result);
            return result.Id;
        }
        
    }
}