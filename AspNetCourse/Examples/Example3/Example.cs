namespace AspNetCourse.Examples.Example3
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddRazorPages(options => options.RootDirectory = "/Examples/Example3/Pages");
            var app = builder.Build();

            app.MapRazorPages();

            app.Run();
        }
    }
}
