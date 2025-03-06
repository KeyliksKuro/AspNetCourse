using Microsoft.AspNetCore.Routing.Patterns;
using System;

namespace Lesson1.Examples.Example4
{
    public class Example1 : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddTransient<TimeService>();

            var app = builder.Build();

            app.Map("/time", (TimeService timeService) => $"Time: {timeService.Time}");
            app.Map("/", () => "Index page");

            app.Run();

        }

        // Сервис
        public class TimeService
        {
            public string Time => DateTime.Now.ToLongTimeString();
        }
    }
}
