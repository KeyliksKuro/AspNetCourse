
//Example1
//Подключение страниц Razor Pages к проекту

//Example2
//Синтаксис Razor Pages

//Example3
//Обработка POST и GET запросов

//Example4
//Маршрутизация и параметры маршрута

//Передача зависимостей в страницу Razor осуществляется следующими способами:
//Через конструктор модели
//В качестве параметра обработчика, с атрибутом [FromServices]
//  public void OnGet([FromServices] ITimeService timeService)
//На саму страницу: @inject ITimeService timeService

//Example5
//Возвращение результата

//Example6
//ViewBag и ViewData

//Example7
//Binding

//Example8
//tag-хелперы

//Example9
//Мастер-страницы layout / Partial

using AspNetCourse.Examples.Example9;

new Example().Run();