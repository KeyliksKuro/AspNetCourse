namespace AspNetCourse.Examples.Example6
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder(
                new WebApplicationOptions { WebRootPath = "Examples/Example6/wwwroot" });
            builder.Services.AddRazorPages(options => options.RootDirectory = "/Examples/Example6/Pages");
            var app = builder.Build();

            app.MapRazorPages();

            app.Run();
        }
    }
}
