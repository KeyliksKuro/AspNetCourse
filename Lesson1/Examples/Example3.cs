namespace Lesson1.Examples.Example3
{
    class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            //Добавление нового сервиса
            //Система на место объектов интерфейса ITimeService будет передавать экземпляры класса ShortTimeService.
            builder.Services.AddTransient<ITimeService, ShortTimeService>();
            //Добавление через метод расширения
            //builder.Services.AddLongTimeService();

            var app = builder.Build();

            app.Run(async context =>
            {
                //Получение сервиса времени из списка всех сервисов
                var timeService = app.Services.GetService<ITimeService>();
                //var timeService = context.RequestServices.GetService<ITimeService>();
                await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
            });

            app.Run();
        }
    }
    //Сервис времени
    interface ITimeService
    {
        string GetTime();
    }
    // время в формате hh::mm
    class ShortTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToShortTimeString();
    }
    // время в формате hh::mm::ss
    class LongTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToLongTimeString();
    }


    //Метод расширения для добавления сервиса
    public static class ServiceProviderExtensions
    {
        public static void AddShortTimeService(this IServiceCollection services)
        {
            services.AddTransient<ITimeService, ShortTimeService>();
        }
        public static void AddLongTimeService(this IServiceCollection services)
        {
            services.AddTransient<ITimeService, LongTimeService>();
        }
    }
}
