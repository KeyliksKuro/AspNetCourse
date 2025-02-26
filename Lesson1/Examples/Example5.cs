using Microsoft.AspNetCore.Http;

namespace Lesson1.Examples.Example5
{

    //Добавление сервиса через параметр метода Invoke компонента middleware
    class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddTransient<ITimeService, ShortTimeService>();

            var app = builder.Build();

            app.UseMiddleware<TimeMessageMiddleware>();

            app.Run();
        }
    }

    //Компонент middleware
    class TimeMessageMiddleware
    {
        private readonly RequestDelegate next;

        public TimeMessageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITimeService timeService)
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync($"<h1>Time: {timeService.GetTime()}</h1>");
        }
    }

    //Сервис
    interface ITimeService
    {
        string GetTime();
    }
    class ShortTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToShortTimeString();
    }
}
