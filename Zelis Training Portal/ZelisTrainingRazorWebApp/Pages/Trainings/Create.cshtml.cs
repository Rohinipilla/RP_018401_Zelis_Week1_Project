using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Training Training { get; set; }

        ITrainingRepository trainingRepo = new ADOTrainingRepository();
        
        public void OnGet()
        {
            // Optional: Load dropdown data here if needed (e.g., Trainer list, Technology list)
        }

        public IActionResult OnPost()
        {
           

            trainingRepo.AddTraining(Training);

            return RedirectToPage("/Trainings/Index");
        }
    }
}
