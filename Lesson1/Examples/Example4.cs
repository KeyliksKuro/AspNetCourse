using Microsoft.AspNetCore.Http;

namespace Lesson1.Examples.Example4
{
    //Способы получения сервиса

    //Через свойство Services объекта WebApplication(service locator)
    //Через свойство RequestServices контекста запроса HttpContext в компонентах middleware(service locator)
    //Через конструктор класса
    //Через параметр метода Invoke компонента middleware
    //Через свойство Services объекта WebApplicationBuilder


    //service locator (расмотренно в предыдущем примере)

    //GetService<service>();
    //использует провайдер сервисов для создания объекта, который представляет тип service.
    //В случае если в провайдере сервисов для данного сервиса не установлена зависимость, то возвращает значение null

    //GetRequiredService<service>();
    //использует провайдер сервисов для создания объекта, который представляет тип service.
    //В случае если в провайдере сервисов для данного сервиса не установлена зависимость, то генерирует исключение


    //Добавление сервиса через конструктор класса
    class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddTransient<ITimeService, ShortTimeService>();
            builder.Services.AddTransient<TimeMessage>();

            var app = builder.Build();

            app.Run(async context =>
            {
                var timeMessage = context.RequestServices.GetService<TimeMessage>();
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync($"<h2>{timeMessage?.GetTime()}</h2>");
            });

            app.Run();
        }
    }

    class TimeMessage
    {
        ITimeService timeService;
        public TimeMessage(ITimeService timeService)
        {
            this.timeService = timeService;
        }
        public string GetTime() => $"Time: {timeService.GetTime()}";
    }
    interface ITimeService
    {
        string GetTime();
    }
    class ShortTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToShortTimeString();
    }
}
