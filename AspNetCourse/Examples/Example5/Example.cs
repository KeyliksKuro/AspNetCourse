namespace AspNetCourse.Examples.Example5
{
    public class Example : IExample
    {
        public void Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // параметры маршрутов могут быть необязательными
            // так же на них можно накладывать все изученные ограничения
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id:int?}");

            //статические сегменты
            app.MapControllerRoute(
                name: "api",
                pattern: "api/{controller}/{action}/{id}");

            // установка значений по умолчанию
            app.MapControllerRoute(
                name: "info",
                pattern: "{action}/{name}/{age}",
                defaults: new { controller = "ex5home", action = "About" });

            app.Run();
        }
    }
}
