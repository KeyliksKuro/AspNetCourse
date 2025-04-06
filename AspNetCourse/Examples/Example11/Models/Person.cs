using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspNetCourse.Examples.Example11.Models
{
    public class Person
    {
        [Required]
        [MinLength(3)]
        public string? Name { get; set; }
        [Required (ErrorMessage = "Необходимо указать возраст.")]
        [Range(18, 100)]
        public int Age { get; set; }
    }
}
//Атрибуты валидации

//Required
//Применение этого атрибута к свойству модели означает,
//что данное свойство должно быть обязательно установлено.

//RegularExpression
//Использование данного атрибута предполагает, что вводимое 
//значение должно соответствовать указанному в этом атрибуте регулярному выражению.

//Атрибут StringLength
//Первым параметром в конструкторе атрибута идет максимальная допустимая длина строки.

//Range
//Атрибут Range определяет минимальные и максимальные значения для числовых данных.

//Compare
//Атрибут Compare гарантирует, что два свойства объекта модели имеют одно и то же значение.
//Пример:
//[Required]
//public string? Password { get; set; }
//[Compare("Password", ErrorMessage = "Пароли не совпадают")]
//public string? PasswordConfirm { get; set; }

//Remote
//Для валидации свойства выполняет запрос на сервер к определенному методу контроллера.
//И если требуемый метод контроллера вернет значение false, то валидация не пройдена.
//Пример:
//[Remote(action: "CheckEmail", controller: "Home", ErrorMessage ="Email уже используется")]
//public string Email { get; set; }
//
//[HttpGet]
//[HttpPost]
//public IActionResult CheckEmail(string email)
//{
//    if (email == "admin@mail.ru")
//        return Json(false);
//    return Json(true);
//}


//Атрибуты аннотации данных

//Display
//Атрибут Display задает параметры отображения для свойства. 

//DataType
//Атрибут DataType позволяет предоставлять среде выполнения информацию об использовании свойства.
//Пример:
//[DataType(DataType.Password)]
//public string? Password { get; set; }


