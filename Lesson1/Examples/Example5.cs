using Microsoft.AspNetCore.Routing.Patterns;
using System;

namespace Lesson1.Examples.Example5
{
    public class Example1 : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                Console.WriteLine("First middleware starts");
                await next.Invoke();
                Console.WriteLine("First middleware ends");
            });
            app.Map("/", () =>
            {
                Console.WriteLine("Index endpoint starts and ends");
                return "Index Page";
            });
            app.Use(async (context, next) =>
            {
                Console.WriteLine("Second middleware starts");
                await next.Invoke();
                Console.WriteLine("Second middleware ends");
            });
            app.Map("/about", () =>
            {
                Console.WriteLine("About endpoint starts and ends");
                return "About Page";
            });

            //терминальный компонент будет выполняться даже если endpoint соответствует запрошенному пути

            app.Run();
        }

    }
}
