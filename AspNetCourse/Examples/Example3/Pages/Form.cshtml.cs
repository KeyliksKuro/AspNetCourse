using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCourse.Examples.Example3.Pages
{
    [IgnoreAntiforgeryToken]
    public class FormModel : PageModel
    {
        public string Message { get; private set; } = "";
        public void OnGet()
        {
            Message = "¬ведите свои данные";
        }
        public void OnGet(Person person)
        {
            Message = $"Person  {person.Name} ({person.Age})";
        }
    }
}
