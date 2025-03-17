using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace AspNetCourse.Examples.Example6.Pages
{

    public class IndexModel : PageModel
    {
        //ViewData представляет словарь из пар ключ-значение
        public void OnGet()
        {
            ViewData["Message"] = "Hello from Razor Pages!";
            ViewData["People"] = new List<string> { "Tom", "Sam", "Bob" };
        }
    }
}
