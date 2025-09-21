using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class DetailsModel : PageModel
    {
        public Trainer Trainer { get; set; }

        ITrainerRepository trainerRepo = new ADOTrainerRepository();
        static int trainId, eid;
        public void OnGet(int trainerId)
        {
            trainId = trainerId;
            
            Trainer = trainerRepo.GetTrainerById(trainId);


        }
    }
}
