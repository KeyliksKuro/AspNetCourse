using Microsoft.AspNetCore.Http;

namespace Lesson1.Examples.Example6
{
    //Типы сервисов:
    
    //Transient: при каждом обращении к сервису создается новый объект сервиса.
    //В течение одного запроса может быть несколько обращений к сервису,
    //соответственно при каждом обращении будет создаваться новый объект.
    //Подобная модель жизненного цикла наиболее подходит для легковесных сервисов,
    //которые не хранят данных о состоянии

    //Scoped: для каждого запроса создается свой объект сервиса.
    //То есть если в течение одного запроса есть несколько обращений к одному сервису,
    //то при всех этих обращениях будет использоваться один и тот же объект сервиса.

    //Singleton: объект сервиса создается при первом обращении к нему,
    //все последующие запросы используют один и тот же ранее созданный объект сервиса


    class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddTransient<ICounter, RandomCounter>();
            builder.Services.AddTransient<CounterService>();

            //builder.Services.AddScoped<ICounter, RandomCounter>();
            //builder.Services.AddScoped<CounterService>();

            //builder.Services.AddSingleton<ICounter, RandomCounter>();
            //builder.Services.AddSingleton<CounterService>();

            var app = builder.Build();

            app.UseMiddleware<CounterMiddleware>();

            app.Run();
        }
    }

    //Сервис
    public class CounterService
    {
        public ICounter Counter { get; }
        public CounterService(ICounter counter)
        {
            Counter = counter;
        }
    }
    public interface ICounter
    {
        int Value { get; }
    }
    public class RandomCounter : ICounter
    {
        static Random rnd = new Random();
        private int _value;
        public RandomCounter()
        {
            _value = rnd.Next(0, 1000000);
        }
        public int Value
        {
            get => _value;
        }
    }

    //middleware
    public class CounterMiddleware
    {
        RequestDelegate next;
        int i = 0;
        public CounterMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, ICounter counter, CounterService counterService)
        {
            i++;
            httpContext.Response.ContentType = "text/html;charset=utf-8";
            await httpContext.Response.WriteAsync($"Запрос {i}; Counter: {counter.Value};" +
                $" Service: {counterService.Counter.Value}");
        }
    }
}
