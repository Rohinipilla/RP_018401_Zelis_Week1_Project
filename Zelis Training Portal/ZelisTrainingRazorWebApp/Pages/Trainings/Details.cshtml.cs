using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class DetailsModel : PageModel
    {
        public Training Training { get; set; }

        ITrainingRepository trainingRepo = new ADOTrainingRepository();
        static int trainId;
        public void OnGet(int trainingId)
        {
            trainId = trainingId;
            Training = trainingRepo.GetTrainingById(trainId);

            
        }
    }
}
