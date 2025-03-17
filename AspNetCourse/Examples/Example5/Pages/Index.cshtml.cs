using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace AspNetCourse.Examples.Example5.Pages
{

    public class IndexModel : PageModel
    {
        IWebHostEnvironment _webHostEnvironment;
        public IndexModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        // �������� ����� �� ����������� ����
        // �������� ������� ������ � ������ ���������� ����������
        public IActionResult OnGetFilePhysical()
        {
            // ���� � �����
            string file_path = Path.Combine(_webHostEnvironment.WebRootPath, "img/logo.png");
            // ��� ����� - content-type
            string file_type = "image/png";
            // ��� ����� - �������������
            string file_name = "cpplogo.png";
            // ��� ���������� �������� ��������� �������� ����������� � ��������
            return PhysicalFile(file_path, file_type, file_name);
        }
        

        //�������� ����� �� ������������ ����
        public IActionResult OnGetFileVirtual()
        {
            string file_path = "img/logo.png";
            string file_type = "image/png";
            string file_name = "cpplogo.png";
            return File(file_path, file_type, file_name);
        }

        //�������� ���������� ����
        public IActionResult OnGetCode()
        {
            return StatusCode(401);
            //return NotFound("Resource not found");
            //return BadRequest("Name undefined");
            //return new OkResult();
            //return new OkObjectResult(new { username = name });
        }

        //�������������
        public IActionResult OnGetRedirect()
        {
            return RedirectToPage("/about");

            // �������� ����������
            //return RedirectToPage("/person", new { name = "Sam", age = 28 })

            // ������������� �� ������
            //return Redirect("about");
        }
    }
}
