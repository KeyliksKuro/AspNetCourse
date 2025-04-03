using Microsoft.AspNetCore.Mvc;

namespace AspNetCourse.Examples.Example10.ViewComponents
{
    public class UserListViewComponent : ViewComponent
    {
        List<string> users = new List<string>
        {
            "Tom", "Tim", "Bob", "Sam"
        };

        //возвращение представление в качестве результата
        public IViewComponentResult Invoke()
        {
            return View("Default", users);
        }
    }
}
