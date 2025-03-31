namespace AspNetCourse.Examples.Example7
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // добавляем поддержку контроллеров, которые располагаются в области
            app.MapControllerRoute(
                name: "Account",
                pattern: "{area:exists}/{controller=ex7home}/{action=Index}/{id?}");

            // маршрут для области account
            //app.MapAreaControllerRoute(
            //    name: "account_area",
            //    areaName: "account",
            //    pattern: "profile/{controller=ex7home}/{action=Index}/{id?}");

            // добавляем поддержку для контроллеров, которые располагаются вне области
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=ex7home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
