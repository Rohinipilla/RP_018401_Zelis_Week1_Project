using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;
namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Technology Technology { get; set; }
        ITechnologyRepository techrepo = new ADOTechnologyRepository();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            techrepo.AddTechnology(Technology);
            return RedirectToPage("/Technologies/Index");
        }
    }
}
