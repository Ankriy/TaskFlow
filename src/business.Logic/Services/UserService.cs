using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Users;

namespace business.Logic.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int GetAllCount(int userid)
        {
            return _userRepository.Count(userid);
        }
        
        public int AddUser(User user)
        {
            var newClient = new User()
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Middlename = user.Middlename,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password
            };
            _userRepository.Create(newClient);
            return newClient.Id;
        }
        public User GetUser(int id)
        {
            
            var user = _userRepository.Get(id);
            return new User()
            {
                Id = id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Middlename = user.Middlename,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password
            };
        }
        public object EditUser(User userUpdate)
        {
            var user = new User()
            {
                Id = userUpdate.Id,
                Firstname = userUpdate.Firstname,
                Lastname = userUpdate.Lastname,
                Middlename = userUpdate.Middlename,
                Email = userUpdate.Email,
                Login = userUpdate.Login,
                Password = userUpdate.Password
            };
            _userRepository.Update(user);
            return userUpdate.Id;
        }
        public void DeleteUser(int idUser)
        {
            _userRepository.Delete(idUser);
        }
    }
}