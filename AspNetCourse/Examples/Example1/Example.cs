namespace AspNetCourse.Examples.Example1
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            // добавляем в приложение сервисы Razor Pages (По умолчанию страницы размещаются в папке Pages)
            //builder.Services.AddRazorPages();
            builder.Services.AddRazorPages(options => options.RootDirectory = "/Examples/Example1/Pages");

            var app = builder.Build();

            // добавляем поддержку маршрутизации для Razor Pages
            app.MapRazorPages();

            app.Run();
        }
    }
}
