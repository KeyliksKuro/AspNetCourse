namespace AspNetCourse.Examples.Example7
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder(
                new WebApplicationOptions { WebRootPath = "Examples/Example7/wwwroot" });
            builder.Services.AddRazorPages(options => options.RootDirectory = "/Examples/Example7/Pages");
            var app = builder.Build();

            app.MapRazorPages();

            app.Run();
        }
    }
}
