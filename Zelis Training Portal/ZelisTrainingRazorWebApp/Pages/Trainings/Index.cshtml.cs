using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class IndexModel : PageModel
    {
        //public List<Training> trainings { get; set; }

        //ITrainingRepository trainingRepo = new ADOTrainingRepository();

        //public void OnGet()
        //{
        //    trainings = trainingRepo.GetAllTrainings();
        //}
        public List<Training> trainings { get; set; }

        ITrainingRepository trainingRepo = new ADOTrainingRepository();

        [BindProperty(SupportsGet = true)]
        public int? TechnologyId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? TrainerId { get; set; }

        public void OnGet()
        {
            if (TechnologyId.HasValue)
            {
                trainings = trainingRepo.GetTrainingsByTechnologyId(TechnologyId.Value);
            }
            else if (TrainerId.HasValue)
            {
                trainings = trainingRepo.GetTrainingsByTrainerId(TrainerId.Value);
            }
            else
            {
                trainings = trainingRepo.GetAllTrainings();
            }
        }
    }
}
