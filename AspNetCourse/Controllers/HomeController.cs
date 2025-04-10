using Application.Services.Abstraction;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AspNetCourse.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IAuthService _authService;
        public HomeController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return Content("SecretData");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            _authService.Register(user);
            return Content($"{user.Id} {user.Login} {user.Password}");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User userData)
        {
            var tokenString = _authService.Login(userData);
            
            // Добавление токена в куки
            HttpContext.Response.Cookies.Append("myToken", tokenString);

            return Redirect("Index");
        }
    }
}
