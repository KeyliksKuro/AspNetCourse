namespace AspNetCourse.Examples.Example6
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}
