using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCourse.Examples.Example2.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
        public string PrintTime() => DateTime.Now.ToShortTimeString();
    }
}
