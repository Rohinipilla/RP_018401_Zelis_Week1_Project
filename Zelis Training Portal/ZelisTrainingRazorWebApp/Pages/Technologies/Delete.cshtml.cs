using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class DeleteModel : PageModel
    {
        public Technology Technology { get; set; }
        ITechnologyRepository techRepo = new ADOTechnologyRepository();
        static int techid;
        public void OnGet(int tid)
        {
            techid = tid;
            Technology = techRepo.GetTechnologyById(tid);
        }
        public IActionResult OnPost()
        {
            techRepo.DeleteTechnology(techid);
            return RedirectToPage("/Technologies/Index");
        }
    }
}
