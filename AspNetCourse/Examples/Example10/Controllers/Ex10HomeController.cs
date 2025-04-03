using Microsoft.AspNetCore.Mvc;

namespace AspNetCourse.Examples.Example10.Controllers
{
    public class Ex10HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
