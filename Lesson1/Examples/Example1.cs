using Microsoft.AspNetCore.Routing.Patterns;
using System;

namespace Lesson1.Examples.Example1
{
    //Метод Map добавляет конечные точки для обработки запросов типа GET.

    //public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints, RoutePattern pattern, Delegate handler);
    //public static IEndpointConventionBuilder Map (this IEndpointRouteBuilder endpoints, string pattern, RequestDelegate requestDelegate);

    //pattern - шаблон маршрута
    //handler - действие, которое будет обрабатывать запрос
    public class Example1 : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.Map("/", () => "Index Page");
            app.Map("/contact", ContactsHandler);
            app.Map("/user", () => new Person("Tom", 37));
            app.Map("/about", async (context) =>
            {
                await context.Response.WriteAsync("About Page");
            });

            app.Run();
        }

        static string ContactsHandler()
        {
            return "Contacts Page";
        }
    }
    record class Person(string Name, int Age);
}
