using Domain.Models;

namespace Application.Services.Abstraction
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        int Create(User user);
    }
}
