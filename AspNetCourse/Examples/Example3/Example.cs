namespace AspNetCourse.Examples.Example3
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddControllers();
            builder.Services.AddTransient<ITimeService, SimpleTimeService>();

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
    public interface ITimeService
    {
        string Time { get; }
    }
    public class SimpleTimeService : ITimeService
    {
        public string Time => DateTime.Now.ToString("hh:mm:ss");
    }
}
