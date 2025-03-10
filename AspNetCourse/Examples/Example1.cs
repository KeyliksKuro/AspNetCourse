namespace AspNetCourse.Examples.Example1
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            app.MapGet("/", () => "Hello World!");
            app.Run();
        }
    }
}
