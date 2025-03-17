using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace AspNetCourse.Examples.Example7.Pages
{

    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = "";

        [BindProperty]
        public int Age { get; set; }

        // Привязка к сложному объекту
        //[BindProperty]
        //public Person? Person { get; set; }

    }
    public record class Person(string Name, int Age);
}
