using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Trainee Trainee { get; set; }

        ITraineeRepository traineeRepo = new ADOTraineeRepository();
        static int traineId,eid;

        public void OnGet(int trainingId, int empId)
        {
            traineId = trainingId;
            eid = empId;
            Trainee = traineeRepo.GetTrainee(traineId, eid);


        }
        public IActionResult OnPost()
        {
            
            traineeRepo.DeleteTrainee(Trainee.TrainingId, Trainee.EmpId);

            return RedirectToPage("/Trainees/Index");
        }
    }
}
