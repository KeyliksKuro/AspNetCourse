using Domain.Models;

namespace Infastructre
{
    public class AppDbContext
    {
        public int currentId = 2;
        public int CurrentId
        {
            get { return currentId++; }
        }
        public List<User> Users { get; set; }
        public AppDbContext()
        {
            Users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Login = "Ivan",
                    Password = "123",
                    Role = "Admin"
                }
            };
        }
    }
}
