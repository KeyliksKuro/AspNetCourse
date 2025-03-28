using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AspNetCourse.Examples.Example1.Controllers
{
    public class MoveParamsController : Controller
    {
        // получение данные через строку запроса
        // можно задавать параметры по умолчанию
        // передача сложных объектов осуществляется как в предыдущих темах
        public string Index(string name, int age = 30)
        {
            // Получение контекста запроса
            var context = HttpContext;

            return $"Hello {name}, your age is {age}";
        }

        // передача массивов
        // /moveparams/people?people=Tom&people=Bob&people=Sam
        public string People(string[] people)
        {
            var sb = new StringBuilder();
            foreach (var person in people)
                sb.AppendLine($"{person};");
            return sb.ToString();
        }
    }
}
