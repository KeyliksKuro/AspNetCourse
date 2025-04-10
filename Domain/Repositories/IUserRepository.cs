using Domain.Models;

namespace Domain.Repositories;

public interface IUserRepository
{
    public IEnumerable<User> GetAll();
    public User? GetById(int id);
    public int Add(User user);
}
