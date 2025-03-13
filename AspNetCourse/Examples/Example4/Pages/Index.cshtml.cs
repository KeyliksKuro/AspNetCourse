using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCourse.Examples.Example4.Pages
{

    public class IndexModel : PageModel
    {
        public int Id { get; private set; }
        public string Game { get; private set; }

        public void OnGet(string game, int? id)
        {
            Game = game;
            Id = id ?? 0;
        }
    }
}
