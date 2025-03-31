
using Microsoft.AspNetCore.Mvc;

namespace AspNetCourse.Examples.Example6.Controllers
{
    // добавление префикса к маршруту
    [Route("ex6home")]
    public class Ex6HomeController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return Content("Home page!");
        }
        [Route("about")]
        public IActionResult About()
        {
            return Content("About page!");
        }
        // пример ограничение параметров маршрута
        // к одному методу возможно применить сразу несколько маршрутов
        [Route("person/{name:minlength(3)}/{age:int}")]
        [Route("{name:minlength(3)}/{age:int}")]
        public string Person(string name, int age)
        {
            return $"name={name} | age={age}";
        }
    }
}
