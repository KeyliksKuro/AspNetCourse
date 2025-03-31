using Microsoft.AspNetCore.Mvc;

namespace AspNetCourse.Areas.Account.Controllers
{
    [Area("Account")]
    public class Ex7HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
