
using Domain.Models;
using Domain.Repositories;

namespace Infastructre.Repositories
{


    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;
        public UserRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
        public int Add(User user)
        {
            user.Id = _context.CurrentId;
            _context.Users.Add(user);
            return user.Id;
        }
    }
}
