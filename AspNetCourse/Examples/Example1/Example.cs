namespace AspNetCourse.Examples.Example1
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder(
                new WebApplicationOptions { WebRootPath = "Examples/Example1/wwwroot" });

            builder.Services.AddControllers(); // добавляем поддержку контроллеров  

            var app = builder.Build();
            app.UseStaticFiles();
            // устанавливаем сопоставление маршрутов с контроллерами
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
