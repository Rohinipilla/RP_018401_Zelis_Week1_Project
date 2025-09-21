using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class IndexModel : PageModel
    {
        //public List<Technology> technologies = new List<Technology>();
        //ITechnologyRepository techRepo = new ADOTechnologyRepository();
        //public void OnGet()
        //{
        //    technologies = techRepo.GetAllTechnologies();
        //}

        ITechnologyRepository techRepo = new ADOTechnologyRepository();

        public List<Technology> technologies = new List<Technology>();

        [BindProperty(SupportsGet = true)]
        public string Level { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Duration { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(Level))
            {
                technologies = techRepo.GetTechnologiesByLevel(Level);
            }
            else if (Duration.HasValue)
            {
                technologies = techRepo.GetTechnologiesByDuration(Duration.Value.ToString());
            }
            else
            {
                technologies = techRepo.GetAllTechnologies();
            }
        }

    }
}
