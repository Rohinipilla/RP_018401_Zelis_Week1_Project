using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }
        IEmployeeRepository emprepo = new ADOEmployeeRepository();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            emprepo.AddEmployee(Employee);
            return RedirectToPage("/Employees/Index");
        }
    }
}
