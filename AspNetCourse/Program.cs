
//Exmaple1
//Подключение страниц Razor Pages к проекту

//Exmaple2
//Синтаксис Razor Pages

//Exmaple3
//Обработка POST и GET запросов

//Exmaple4
//Маршрутизация и параметры маршрута

//Передача зависимостей в страницу Razor осуществляется следующими способами:
//Через конструктор модели
//В качестве параметра обработчика, с атрибутом [FromServices]
//  public void OnGet([FromServices] ITimeService timeService)
//На саму страницу: @inject ITimeService timeService

//Exmaple5
//Возвращение результата

//Exmaple6
//ViewBag и ViewData

//Exmaple7
//Binding

//Exmaple8
//tag-хелперы

using AspNetCourse.Examples.Example8;

new Example().Run();