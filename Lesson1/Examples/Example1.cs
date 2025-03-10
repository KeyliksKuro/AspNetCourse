namespace Lesson1.Examples.Example1
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear(); // удаляем имена файлов по умолчанию
            options.DefaultFileNames.Add("html/index.html"); // добавляем новое имя файла
            app.UseDefaultFiles(options); // использование index.html для корня сайта

            app.UseStaticFiles();   // добавляем поддержку статических файлов

            app.Run(async (context) => await context.Response.WriteAsync("Hello World"));

            app.Run();
        }
    }
}
