namespace AspNetCourse.Examples.Example4
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddRazorPages(options => options.RootDirectory = "/Examples/Example4/Pages");
            var app = builder.Build();

            app.MapRazorPages();

            app.Run();
        }
    }
}
