using Microsoft.AspNetCore.Mvc;

namespace AspNetCourse.Examples.Example2.Controllers
{
    // Возвращаемые результаты:
    // ContentResult: отправляет в ответ в виде строки
    // EmptyResult: отправляет пустой ответ в виде статусного кода 200
    // NoContentResult: отправляет пустой ответ в виде статусного кода 204

    // файлы
    // FileContentResult: производный от FileResult, пишет в ответ массив байтов
    // VirtualFileResult: производный от FileResult, пишет в ответ файл, находящийся по заданному физическому пути
    // PhysicalFileResult: производный от FileResult, пишет в ответ файл, находящийся по заданному виртуальному пути
    // FileStreamResult: производный от FileResult, пишет бинарный поток в выходной ответ

    // RedirectResult: перенаправляет пользователя по другому адресу URL, возвращая статусный код 302
    // RedirectToRouteResult: класс работает подобно RedirectResult, но перенаправляет пользователя по определенному
    // адресу URL, указанному через параметры маршрута
    // RedirectToActionResult: выполняет переадресацию на определенный метод контроллера

    // JsonResult: возвращает в качестве ответа объект или набор объектов в формате JSON
    // ViewResult: производит рендеринг представления и отправляет результаты рендеринга в виде html-страницы клиенту
    //public class HomeController : Controller
    //{
    //    //Пример
    //    public IActionResult Index()
    //    {
    //        return RedirectToRoute("default", new { controller = "Home", action = "About", name = "Tom", age = 22 });
    //    }

    //    public IActionResult About(string name, int age)
    //    {
    //        return Json(new { Name = name, Age = age });
    //    }
    //}
}
