using Repository;
using Entities;
//using System.Text.Json;

namespace Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int CheckPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }
        public async Task<User> Register(User user)
        {
            return await _userRepository.Register(user);
        }
        public async Task<User> Login(UserLogin userLogin)
        {
            return await _userRepository.Login(userLogin);
        }
        public async Task<User> Update(int id, User userToUpdate)
        {
            return await _userRepository.Update(id, userToUpdate);
        }
    }
}
