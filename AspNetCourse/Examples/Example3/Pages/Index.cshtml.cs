using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCourse.Examples.Example3.Pages
{
    // Доступные свойства:
    // PageContext, содержащий данные запросы, в частности объект HttpContext
    public class IndexModel : PageModel
    {
        public string Message { get; private set; } = "";
        // Данный метод обрабатывает входящие Get запросы
        // Получаем параметры из строки запроса, можно указывать значения по умолчанию
        public void OnGet(string name, int age = 30)
        {
            Message = $"Name: {name}  Age: {age}";
        }
        // Передача сложных объектов в обработчике Person
        // /index?handler=person&name=Ivan&age=30
        public void OnGetPerson(Person person)
        {
            Message = $"Name: {person.Name}  Age: {person.Age}";
        }
    }
    public record class Person(string Name, int Age);
}
