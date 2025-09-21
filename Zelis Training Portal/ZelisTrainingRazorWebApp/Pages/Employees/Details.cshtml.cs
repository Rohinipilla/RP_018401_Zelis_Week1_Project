using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        public Employee Employee { get; set; }
        IEmployeeRepository emprepo = new ADOEmployeeRepository();

        public void OnGet(int eid)
        {
            Employee = emprepo.GetEmployeeById(eid);
        }
    }
}
