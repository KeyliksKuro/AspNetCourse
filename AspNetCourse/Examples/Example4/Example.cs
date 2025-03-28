namespace AspNetCourse.Examples.Example4
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
