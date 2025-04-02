namespace AspNetCourse.Examples.Example8
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
                pattern: "{controller=ex8home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
