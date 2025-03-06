using Lesson1.Examples.Example1;
using Microsoft.AspNetCore.Routing.Patterns;
using System;

namespace Lesson1.Examples.Example6
{
    public class Example1 : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            // /user?name=Tom&age=39
            app.MapGet("/user", (string name, int? age) => $"Name: {name} Age: {age??0}");

            // /person?name=Tom&age=39
            app.MapGet("/person", ([AsParameters] Person person) => $"Name: {person.Name} Age: {person.Age}");

            app.MapGet("/", () => "Home page");
            app.Run();
        }
    }
    public record Person(string Name, int Age);
}
