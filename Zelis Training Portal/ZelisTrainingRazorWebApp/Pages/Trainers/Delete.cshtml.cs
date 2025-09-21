using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Trainer Trainer { get; set; }

        ITrainerRepository trainerRepo = new ADOTrainerRepository();
        static int trainerId;

        public void OnGet(int trainingId)
        {
            trainerId = trainingId;
            
            Trainer = trainerRepo.GetTrainerById(trainerId);


        }
        public IActionResult OnPost()
        {

            trainerRepo.DeleteTrainer(Trainer.TrainerId);

            return RedirectToPage("/Trainers/Index");
        }
    }
}
