using Application.Services.Abstraction;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User? GetById(int id)
        {
            return _userRepository.GetById(id);
        }
        public int Create(User user)
        {
            _userRepository.Add(user);
            return user.Id;
        }

    }
}
