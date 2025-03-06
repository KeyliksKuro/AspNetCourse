using Microsoft.AspNetCore.Routing.Patterns;
using System;

namespace Lesson1.Examples.Example2
{

    public class Example1 : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            //Для параметров необходимо обязательно указывать тип данных

            app.Map("/users/{id}", (int id) => $"User Id: {id}");

            app.Map("/users/{id}/{name}",
                (string id, string name) => $"User Id: {id}   User Name: {name}");

            //Необязательные параметры
            app.Map("/product/{id?}", (string? id) => $"User Id: {id ?? "Undefined"}");

            //Значения параметров по умолчанию
            app.Map("{controller=Home}/{action=Index}/{id?}",
                (string controller, string action, string? id) =>
                $"Controller: {controller} \nAction: {action} \nId: {id}");

            app.Map("/users", () => "Users Page");
            //app.Map("/", () => "Index Page");

            app.Run();
        }
    }
}
