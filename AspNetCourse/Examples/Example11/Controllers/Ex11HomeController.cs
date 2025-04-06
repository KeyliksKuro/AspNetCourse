using AspNetCourse.Examples.Example11.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCourse.Examples.Example11.Controllers
{
    public class Ex11HomeController : Controller
    {
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Person person)
        {
            // Дополнительная валидация на сервере.
            if (person.Name == "admin")
                ModelState.AddModelError("Name", "admin - запрещенное имя.");

            if (ModelState.IsValid)
                return Content($"{person.Name} - {person.Age}");

            return Content("Данные не прошли валидацию");
            // Или отправляем объект обратно пользователю, для изменения
            return View(person);
        }
    }
}
