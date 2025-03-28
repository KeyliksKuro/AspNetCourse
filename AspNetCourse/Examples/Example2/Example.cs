namespace AspNetCourse.Examples.Example2
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder(
                new WebApplicationOptions { WebRootPath = "Examples/Example2/wwwroot" });

            builder.Services.AddControllers();

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
