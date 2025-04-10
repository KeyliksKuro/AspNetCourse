using Application.Services.Abstraction;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.Services.Implementation
{
    public class JwtAuthService : IAuthService
    {
        private IUserService _userService;
        public JwtAuthService(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(User userData)
        {
            var users = _userService.GetAll();
            var user = users.FirstOrDefault(x => userData.Login == x.Login);
            if (user == null)
                throw new Exception("Пользователь не найден");

            if (userData.Password != user.Password)
                throw new Exception("Пароль не верный");

            // Алгоритм кодирования токена
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("securitykeysecuritykeysecuritykeysecuritykeysecuritykeysecuritykeysecuritykeysecuritykey")),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        public int Register(User user)
        {
            // TODO: хеширование пароля
            _userService.Create(user);
            return user.Id;
        }
    }
}
