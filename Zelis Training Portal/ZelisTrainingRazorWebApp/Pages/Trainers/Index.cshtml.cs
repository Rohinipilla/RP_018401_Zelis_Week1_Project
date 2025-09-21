using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class IndexModel : PageModel
    {
        //public List<Trainer> trainers = new List<Trainer>();
        //ITrainerRepository tRepo = new ADOTrainerRepository();
        //public void OnGet()
        //{
        //    trainers = tRepo.GetAllTrainers();
        //}
        public List<Trainer> trainers = new List<Trainer>();
        ITrainerRepository tRepo = new ADOTrainerRepository();

        [BindProperty(SupportsGet = true)]
        public string? Type { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(Type))
            {
                trainers = tRepo.GetTrainersByType(Type);
            }
            else
            {
                trainers = tRepo.GetAllTrainers();
            }
        }
    }

}
