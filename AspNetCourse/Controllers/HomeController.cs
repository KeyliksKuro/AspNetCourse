using Application.Services.Abstraction;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            // Получение информации из claims
            //var name = HttpContext.User.Identity?.Name;
            var name = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            return Content($"Привет {name}");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Admin()
        {
            return Content("Панель администратора.");
        }

        [Authorize(Policy = "NotForOlegs")]
        [HttpGet]
        public IActionResult SecretInfo()
        {
            return Content("Информация не для Олегов");
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
