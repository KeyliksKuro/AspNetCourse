namespace AspNetCourse.Examples.Example11
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
                pattern: "{controller=ex11home}/{action=Create}/{id?}");

            app.Run();
        }
    }
}
