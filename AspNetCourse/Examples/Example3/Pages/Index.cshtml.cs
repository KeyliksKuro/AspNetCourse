using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCourse.Examples.Example3.Pages
{
    // ��������� ��������:
    // PageContext, ���������� ������ �������, � ��������� ������ HttpContext
    public class IndexModel : PageModel
    {
        public string Message { get; private set; } = "";
        // ������ ����� ������������ �������� Get �������
        // �������� ��������� �� ������ �������, ����� ��������� �������� �� ���������
        public void OnGet(string name, int age = 30)
        {
            Message = $"Name: {name}  Age: {age}";
        }
        // �������� ������� �������� � ����������� Person
        // /index?handler=person&name=Ivan&age=30
        public void OnGetPerson(Person person)
        {
            Message = $"Name: {person.Name}  Age: {person.Age}";
        }
    }
    public record class Person(string Name, int Age);
}
