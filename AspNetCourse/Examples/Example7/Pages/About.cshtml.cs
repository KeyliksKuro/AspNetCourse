using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace AspNetCourse.Examples.Example7.Pages
{
    public class AboutModel : PageModel
    {
        // �������������� �������� ��� ��������� get ��������
        // � ��� �� ��������� �������� ���������
        [BindProperty(SupportsGet = true, Name = "mess")]
        public string? Message { get; set; }

    }
}
