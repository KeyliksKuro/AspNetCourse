using Lesson1.Examples.Example6;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.Design;

namespace Lesson1.Examples.Example9
{


    class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddSingleton<IGenerator, ValueStorage>();
            builder.Services.AddSingleton<IReader, ValueStorage>();

            var app = builder.Build();

            app.UseMiddleware<GeneratorMiddleware>();
            app.UseMiddleware<ReaderMiddleware>();
        }
    }
    //Сервисы
    interface IGenerator
    {
        int GenerateValue();
    }
    interface IReader
    {
        int ReadValue();
    }
    class ValueStorage : IGenerator, IReader
    {
        int value;
        public int GenerateValue()
        {
            value = new Random().Next();
            return value;
        }

        public int ReadValue() => value;
    }

    //middleware
    class GeneratorMiddleware
    {
        RequestDelegate next;
        IGenerator generator;

        public GeneratorMiddleware(RequestDelegate next, IGenerator generator)
        {
            this.next = next;
            this.generator = generator;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/generate")
                await context.Response.WriteAsync($"New Value: {generator.GenerateValue()}");
            else
                await next.Invoke(context);
        }
    }
    class ReaderMiddleware
    {
        IReader reader;

        public ReaderMiddleware(RequestDelegate _, IReader reader)
        {
            this.reader = reader;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync($"Current Value: {reader.ReadValue()}");
        }
    }
}