
using Microsoft.AspNetCore.Mvc;

namespace AspNetCourse.Examples.Example5.Controllers
{
    public class Ex5HomeController : Controller
    {
        public string Index(int? id)
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            return $"controller: {controller} | action: {action} | id: {id}";
        }
        public string About(string name, int age)
        {
            return $"About Page. Name: {name}  Age: {age}";
        }
    }
}
