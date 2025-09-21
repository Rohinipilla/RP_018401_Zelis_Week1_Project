using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class DetailsModel : PageModel
    {
        public Technology Technology { get; set; }
        ITechnologyRepository techrepo = new ADOTechnologyRepository();

        public void OnGet(int tid)
        {
            Technology = techrepo.GetTechnologyById(tid);
        }
    }
}
