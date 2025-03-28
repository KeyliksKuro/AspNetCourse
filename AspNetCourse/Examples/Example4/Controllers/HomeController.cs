using AspNetCourse.Examples.Example4.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCourse.Examples.Example4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "ASP.NET MVC";
            return View(new Person() { Name = "Ivan", Age = 30});
        }

    }
}
