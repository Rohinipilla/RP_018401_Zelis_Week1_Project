using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Trainer Trainer { get; set; }

        ITrainerRepository trainerRepo = new ADOTrainerRepository();
        static int trainId;

        public void OnGet(int trainerId)
        {
            trainId = trainerId;
            
            Trainer = trainerRepo.GetTrainerById(trainId);
        }

        public IActionResult OnPost()
        {
            trainerRepo.UpdateTrainer(trainId,Trainer);
            return RedirectToPage("/Trainers/Index");
        }
    }
}
