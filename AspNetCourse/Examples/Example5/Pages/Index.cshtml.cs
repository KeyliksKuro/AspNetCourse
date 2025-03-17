using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace AspNetCourse.Examples.Example5.Pages
{

    public class IndexModel : PageModel
    {
        IWebHostEnvironment _webHostEnvironment;
        public IndexModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        // Загрузка файла по физическому пути
        // Загрузка массива байтов и потока происходит аналогично
        public IActionResult OnGetFilePhysical()
        {
            // Путь к файлу
            string file_path = Path.Combine(_webHostEnvironment.WebRootPath, "img/logo.png");
            // Тип файла - content-type
            string file_type = "image/png";
            // Имя файла - необязательно
            string file_name = "cpplogo.png";
            // При отсутствии третьего параметра картинка отобразится в браузере
            return PhysicalFile(file_path, file_type, file_name);
        }
        

        //Загрузка файла по виртуальному пути
        public IActionResult OnGetFileVirtual()
        {
            string file_path = "img/logo.png";
            string file_type = "image/png";
            string file_name = "cpplogo.png";
            return File(file_path, file_type, file_name);
        }

        //Отправка статусного кода
        public IActionResult OnGetCode()
        {
            return StatusCode(401);
            //return NotFound("Resource not found");
            //return BadRequest("Name undefined");
            //return new OkResult();
            //return new OkObjectResult(new { username = name });
        }

        //Переадресация
        public IActionResult OnGetRedirect()
        {
            return RedirectToPage("/about");

            // Передача параметров
            //return RedirectToPage("/person", new { name = "Sam", age = 28 })

            // Переадресация по адресу
            //return Redirect("about");
        }
    }
}
