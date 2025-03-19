using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCourse.Examples.Example8.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "About";
        }
        public void OnGetCompany()
        {
            Message = "About company";
        }
        public void OnGetPerson(string name)
        {
            Message = $"About person\nName: {name}";
        }

    }
}
