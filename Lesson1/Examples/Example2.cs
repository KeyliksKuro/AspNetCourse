namespace Lesson1.Examples.Example2
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.UseStaticFiles();

            app.Map("/hello", () => Results.Text("Привет мир!"));

            app.Map("/text", () => Results.Content("Привет мир!", "text/plain", System.Text.Encoding.Unicode));

            app.Map("/json", () => Results.Json(new Person("Bob", 41)));

            app.Map("/code", () => Results.StatusCode(401));
            app.Map("/error404", () => Results.NotFound("Error 404. Invalid address"));

            app.Map("/img", async (IWebHostEnvironment hostEnvironment) =>
            {
                string path = Path.Combine(hostEnvironment.WebRootPath, "img/aspnetcore_logo.png");
                byte[] fileContent = await File.ReadAllBytesAsync(path);
                //FileStream fileContent = new FileStream(path, FileMode.Open);
                string contentType = "image/png";
                string downloadName = "logo.png";
                //return Results.File(fileContent, contentType, downloadName);
                return Results.File(path, contentType, downloadName);
            });

            app.Map("/index", () =>
            {
                var filePath = Path.Combine(app.Environment.WebRootPath, "html/index.html");
                string contentType = "text/html";
                return Results.File(filePath, contentType);
            });

            app.Map("/", () => "Hello ASP.NET Core");

            app.Run();
        }
    }
    record class Person(string Name, int Age);
}