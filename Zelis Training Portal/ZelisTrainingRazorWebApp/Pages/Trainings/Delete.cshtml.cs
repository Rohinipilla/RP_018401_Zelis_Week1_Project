using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class DeleteModel : PageModel
    {
        public Training Training { get; set; }
        ITrainingRepository trainRepo = new ADOTrainingRepository();
        static int trainid;
        public void OnGet(int tid)
        {
            trainid = tid;
            Training = trainRepo.GetTrainingById(trainid);
        }
        public IActionResult OnPost()
        {
            trainRepo.DeleteTraining(trainid);
            return RedirectToPage("/Trainings/Index");
        }
    }
}

