using Microsoft.AspNetCore.Routing.Patterns;
using System;

namespace Lesson1.Examples.Example3
{
    //Возможные ограничения:

    //ограничения типов данных
    //minlength(value)
    //maxlength(value)
    //length(value)
    //min(value)
    //max(value)
    //range(min, max)
    //alpha
    //regex(expression)
    //required

    public class Example1 : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.Map("/users/{id:int}", (int id) => $"User Id: {id}");

            //Комбинация ограничений
            app.Map("/users/{name:alpha:minlength(2)}/{age:int:range(1, 110)}",
                (string name, int age) => $"User Age: {age} \nUser Name:{name}");

            app.Map("/", () => "Index Page");

            app.Run();
        }
    }
}
