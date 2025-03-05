using Lesson1.Examples.Example6;
using Microsoft.AspNetCore.Http;

namespace Lesson1.Examples.Example7
{


    class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddTransient<TimeService>();

            var app = builder.Build();

            app.UseMiddleware<TimerMiddleware>();
            app.Run(async (context) => await context.Response.WriteAsync("Home page"));

            app.Run();
        }
    }

    //Сервис
    public class TimeService
    {
        public TimeService()
        {
            Time = DateTime.Now.ToLongTimeString();
        }
        public string Time { get; }
    }

    //middleware
    public class TimerMiddleware
    {
        RequestDelegate next;
        TimeService timeService;

        public TimerMiddleware(RequestDelegate next, TimeService timeService)
        {
            this.next = next;
            this.timeService = timeService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/time")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}