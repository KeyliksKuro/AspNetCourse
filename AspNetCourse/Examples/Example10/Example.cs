namespace AspNetCourse.Examples.Example10
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddTransient<ITimeService, SimpleTimeService>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=ex10home}/{action=Index}/{id?}");

            app.Run();
        }
    }
    public interface ITimeService
    {
        string GetTime();
    }
    public class SimpleTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToString("HH:mm:ss");
    }
}
