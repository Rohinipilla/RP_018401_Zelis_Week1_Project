using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Trainer Trainer { get; set; }

        ITrainerRepository trainerRepo = new ADOTrainerRepository();

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            trainerRepo.AddTrainer(Trainer);
            return RedirectToPage("/Trainers/Index");
        }
    }
}
