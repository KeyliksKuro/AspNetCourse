namespace AspNetCourse.Examples.Example8
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder(
                new WebApplicationOptions { WebRootPath = "Examples/Example8/wwwroot" });
            builder.Services.AddRazorPages(options => options.RootDirectory = "/Examples/Example8/Pages");
            var app = builder.Build();

            app.MapRazorPages();

            app.Run();
        }
    }
}
