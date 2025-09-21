using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class DetailsModel : PageModel
    {
        public Trainee Trainee { get; set; }

        ITraineeRepository traineeRepo = new ADOTraineeRepository();
        static int trainId, eid;
        public void OnGet(int trainingId, int empId)
        {
            trainId = trainingId;
            eid = empId;
            Trainee = traineeRepo.GetTrainee(trainId, eid);

            
        }
    }
}
