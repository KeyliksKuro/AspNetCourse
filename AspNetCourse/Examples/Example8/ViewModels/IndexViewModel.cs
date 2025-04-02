using AspNetCourse.Examples.Example8.Models;

namespace AspNetCourse.Examples.Example8.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Person> People { get; set; } = new List<Person>();
        public IEnumerable<CompanyModel> Companies { get; set; } = new List<CompanyModel>();
    }
}
