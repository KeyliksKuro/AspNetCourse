using Lesson1.middleware;

//Базовое приложение
void Example1() {
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    //Свойства
    //Configuration: представляет конфигурацию приложения в виде объекта IConfiguration
    //Environment: представляет окружение приложения в виде IWebHostEnvironment
    //Lifetime: позволяет получать уведомления о событиях жизненного цикла приложения
    //Logger: представляет логгер приложения по умолчанию
    //Services: представляет сервисы приложения
    //Urls: представляет набор адресов, которые использует сервер

    app.MapGet("/", () => "Hello World!");
    //Компоненты middleware встраиваются с помощью методов расширений Run, Map и Use интерфейса IApplicationBuilder
    //app.UseWelcomePage();

    app.Run();
}

//Метод Run и объект HttpContext
void Example2()
{
    //Создание middleware
    //public delegate Task RequestDelegate(HttpContext context);
    //Свойства HttpContext
    //Connection: представляет информацию о подключении, которое установлено для данного запроса
    //Features: получает коллекцию HTTP-функциональностей, которые доступны для этого запроса
    //Items: получает или устанавливает коллекцию пар ключ-значение для хранения некоторых данных для текущего запроса
    //Request: возвращает объект HttpRequest, который хранит информацию о текущем запросе
    //RequestAborted: уведомляет приложение, когда подключение прерывается, и соответственно обработка запроса должна быть отменена
    //RequestServices: получает или устанавливает объект IServiceProvider, который предоставляет доступ к контейнеру сервисов запроса
    //Response: возвращает объект HttpResponse, который позволяет управлять ответом клиенту
    //Session: хранит данные сессии для текущего запроса
    //TraceIdentifier: представляет уникальный идентификатор запроса для логов трассировки
    //User: представляет пользователя, ассоциированного с этим запросом
    //WebSockets: возвращает объект для управления подключениями WebSocket для данного запроса

    var builder = WebApplication.CreateBuilder();

    var app = builder.Build();

    app.Run(async (context) => await context.Response.WriteAsync(DateTime.Now.ToLongDateString()));
    //app.Run(HandleRequst);

    app.Run();

    async Task HandleRequst(HttpContext context)
    {
        await context.Response.WriteAsync(DateTime.Now.ToLongDateString());
    }
}

//Response
void Example3()
{
    //Свойства Response
    
    //Body: получает или устанавливает тело ответа в виде объекта Stream
    //BodyWriter: возвращает объект типа PipeWriter для записи ответа
    //ContentLength: получает или устанавливает заголовок Content-Length
    //ContentType: получает или устанавливает заголовок Content-Type
    //Cookies: возвращает куки, отправляемые в ответе
    //HasStarted: возвращает true, если отправка ответа уже началась
    //Headers: возвращает заголовки ответа
    //Host: получает или устанавливает заголовок Host
    //HttpContext: возвращает объект HttpContext, связанный с данным объектом Response
    //StatusCode: возвращает или устанавливает статусный код ответа

    var builder = WebApplication.CreateBuilder();
    var app = builder.Build();

    app.Run(HandleRequst);
    //app.Run(HandleRequstHtml);

    app.Run();

    async Task HandleRequst(HttpContext context)
    {
        var response = context.Response;
        response.Headers.ContentLanguage = "ru-RU";
        response.Headers.ContentType = "text/plain; charset=utf-8";

        response.StatusCode = 200;

        await response.WriteAsync(DateTime.Now.ToLongDateString());
    }
    //Отправка html
    async Task HandleRequstHtml(HttpContext context)
    {
        var response = context.Response;
        response.ContentType = "text/html; charset=utf-8";

        await response.WriteAsync("<h1>Hello world!</h1>");
    }
}

//Request
void Example4()
{
    //Свойства Request
    //Body: предоставляет тело запроса в виде объекта Stream
    //BodyReader: возвращает объект типа PipeReader для чтения тела запроса
    //ContentLength: получает или устанавливает заголовок Content-Length
    //ContentType: получает или устанавливает заголовок Content-Type
    //Cookies: возвращает коллекцию куки (объект Cookies), ассоциированных с данным запросом
    //Form: получает или устанавливает тело запроса в виде форм
    //HasFormContentType: проверяет наличие заголовка Content-Type
    //Headers: возвращает заголовки запроса
    //Host: получает или устанавливает заголовок Host
    //HttpContext: возвращает связанный с данным запросом объект HttpContext
    //IsHttps: возвращает true, если применяется протокол https
    //Method: получает или устанавливает метод HTTP
    //Path: получает или устанавливает путь запроса в виде объекта RequestPath
    //PathBase: получает или устанавливает базовый путь запроса. Такой путь не должен содержать завершающий слеш
    //Protocol: получает или устанавливает протокол, например, HTTP
    //Query: возвращает коллекцию параметров из строки запроса
    //QueryString: получает или устанавливает строку запроса
    //RouteValues: получает данные маршрута для текущего запроса
    //Scheme: получает или устанавливает схему запроса HTTP

    var builder = WebApplication.CreateBuilder();
    var app = builder.Build();
    app.Run(HandleRequstHeaders);
    app.Run();

    async Task HandleRequstHeaders(HttpContext context)
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        var stringBuilder = new System.Text.StringBuilder("<table>");

        foreach (var header in context.Request.Headers)
        {
            stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
        }
        stringBuilder.Append("</table>");
        await context.Response.WriteAsync(stringBuilder.ToString());
    }
    async Task HandleRequstPath(HttpContext context)
    {
        var path = context.Request.Path;
        var response = context.Response;

        if (path == "/date")
            await response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}");
        else if (path == "/time")
            await response.WriteAsync($"Time: {DateTime.Now.ToShortTimeString()}");
        else
            await response.WriteAsync("Страница не найдена.");
    }
    //Строка запроса
}

//Обработка формы
void Example5()
{
    var builder = WebApplication.CreateBuilder();
    var app = builder.Build();

    app.Run(HandleRequst);
    app.Run();

    async Task HandleRequst(HttpContext context)
    {
        context.Response.ContentType = "text/html; charset=utf-8";

        if (context.Request.Path == "/postuser")
        {
            var form = context.Request.Form;
            string name = form["name"];
            string age = form["age"];
            await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>");
        }
        else
        {
            await context.Response.SendFileAsync("html/Example5.html");
        }
    }
}

//Работа с Json
void Example6()
{
    var builder = WebApplication.CreateBuilder();
    var app = builder.Build();

    app.Run(HandleRequst);
    app.Run();

    async Task HandleRequst(HttpContext context)
    {
        var response = context.Response;
        var request = context.Request;
        if (request.Path == "/api/user")
        {
            var message = "Некорректные данные";   // содержание сообщения по умолчанию
            try
            {
                // пытаемся получить данные json
                var person = await request.ReadFromJsonAsync<Person>();
                if (person != null) // если данные сконвертированы в Person
                    message = $"Name: {person.Name}  Age: {person.Age}";
            }
            catch
            {
                app.Logger.LogError("Ошибка чтения данных.");
            }
            // отправляем пользователю данные
            await response.WriteAsJsonAsync(new { text = message });
        }
        else
        {
            response.ContentType = "text/html; charset=utf-8";
            await response.SendFileAsync("html/Example6.html");
        }
    }
}

//Метод Use
void Example7()
{
    var builder = WebApplication.CreateBuilder();
    var app = builder.Build();

    string date = "";

    app.Use(async (context, next) =>
    {
        date = DateTime.Now.ToShortDateString();
        await next.Invoke();
        Console.WriteLine($"Current date: {date}");
    });
    //app.Use(async (context, next) =>
    //{
    //    date = DateTime.Now.ToShortDateString();
    //    await next.Invoke(context);                 // здесь next - RequestDelegate
    //    Console.WriteLine($"Current date: {date}");
    //});

    app.Run(async (context) => await context.Response.WriteAsync($"Date: {date}"));
    app.Run();


    async Task GetDateFunc(HttpContext context, Func<Task> next)
    {
        date = DateTime.Now.ToShortDateString();
        await next.Invoke();
        Console.WriteLine($"Current date: {date}");
    }
    async Task GetDateRequestDelegate(HttpContext context, RequestDelegate next)
    {
        date = DateTime.Now.ToShortDateString();
        await next.Invoke(context);
        Console.WriteLine($"Current date: {date}");
    }
    async Task GetDateRequestTerminal(HttpContext context, RequestDelegate next)
    {
        string path = context.Request.Path;
        if (path == "/date")
        {
            await context.Response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}");
        }
        else
        {
            await next.Invoke(context);
        }
    }
}

//Метод UseWhen
void Example8()
{

}
//Метод Map
void Example9()
{
    var builder = WebApplication.CreateBuilder();
    var app = builder.Build();

    app.Map("/time", appBuilder =>
    {
        var time = DateTime.Now.ToShortTimeString();

        appBuilder.Use(async (context, next) =>
        {
            Console.WriteLine($"Time: {time}");
            await next();
        });

        appBuilder.Run(async context => await context.Response.WriteAsync($"Time: {time}"));
    });

    app.Run(async (context) => await context.Response.WriteAsync("Hello world!"));

    app.Run();
}

//Вложенный Map
void Example10()
{
    var builder = WebApplication.CreateBuilder();
    var app = builder.Build();

    app.Map("/home", appBuilder =>
    {
        appBuilder.Map("/index", Index);
        appBuilder.Map("/about", About); 

        appBuilder.Run(async (context) => await context.Response.WriteAsync("Home Page"));
    });

    app.Run(async (context) => await context.Response.WriteAsync("Page Not Found"));

    app.Run();

    void Index(IApplicationBuilder appBuilder)
    {
        appBuilder.Run(async context => await context.Response.WriteAsync("Index Page"));
    }
    void About(IApplicationBuilder appBuilder)
    {
        appBuilder.Run(async context => await context.Response.WriteAsync("About Page"));
    }
}

//Класс middleware
void Example11()
{
    var builder = WebApplication.CreateBuilder();
    var app = builder.Build();

    app.UseMiddleware<TimeMiddleware>();
    //Добавление через метод расширения
    //app.UseTime();

    app.Run(async (context) => await context.Response.WriteAsync("Home page"));

    app.Run();
}


public record Person(string Name, int Age);