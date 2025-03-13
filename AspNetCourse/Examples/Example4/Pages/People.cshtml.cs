using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCourse.Examples.Example4.Pages
{
    public class PeopleModel : PageModel
    {
        // начальные данные - список людей
        List<Person> people = new()
        {
            new Person ("Tom Smith", 23),
            new Person ("Sam Anderson", 23),
            new Person ("Bob Johnson", 25),
            new Person ("Tom Anderson", 25)
        };
        // отображаемые данные
        public List<Person> DisplayedPeople { get; private set; } = new();

        public void OnGet()
        {
            DisplayedPeople = people;
        }

        public void OnGetByName(string name)
        {
            DisplayedPeople = people.Where(p => p.Name.Contains(name)).ToList();
        }
        public void OnGetByAge(int age)
        {
            DisplayedPeople = people.Where(p => p.Age == age).ToList();
        }
    }
    public record class Person(string Name, int Age);
}
