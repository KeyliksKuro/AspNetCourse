using Domain.Models;

namespace Application.Services.Abstraction
{
    public interface IAuthService
    {
        int Register(User user);
        string Login(User user);
    }
}
