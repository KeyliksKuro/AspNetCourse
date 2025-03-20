namespace AspNetCourse.Examples.Example9
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder(
                new WebApplicationOptions { WebRootPath = "Examples/Example9/wwwroot" });
            builder.Services.AddRazorPages(options => options.RootDirectory = "/Examples/Example9/Pages");
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapRazorPages();

            app.Run();
        }
    }
}
