using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }
        IEmployeeRepository empRepo = new ADOEmployeeRepository();
        static int empid;

        public void OnGet(int eid)
        {
            empid = eid;
            Employee = empRepo.GetEmployeeById(eid);
        }
        public IActionResult OnPost()
        {
            empRepo.UpdateEmployee(empid, Employee);
            return RedirectToPage("/Employees/Index");
        }
    }
}
