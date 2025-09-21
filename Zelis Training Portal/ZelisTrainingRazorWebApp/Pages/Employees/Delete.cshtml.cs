using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class DeleteModel : PageModel
    {
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
            empRepo.DeleteEmployee(empid);
            return RedirectToPage("/Employees/Index");
        }
    }
}
