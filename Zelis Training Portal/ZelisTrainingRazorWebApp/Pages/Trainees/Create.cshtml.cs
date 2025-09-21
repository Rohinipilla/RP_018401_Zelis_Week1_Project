using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Trainee Trainee { get; set; }

        ITraineeRepository traineeRepo = new ADOTraineeRepository();

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            
            traineeRepo.AddTrainee(Trainee);
            return RedirectToPage("/Trainees/Index");
        }
    }
}
