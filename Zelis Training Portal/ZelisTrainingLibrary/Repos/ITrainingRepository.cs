using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITrainingRepository
    {
        void AddTraining(Training training);
        Training GetTrainingById(int trainingId);
        List<Training> GetAllTrainings();
        List<Training> GetTrainingsByTrainerId(int trainerId);
        List<Training> GetTrainingsByTechnologyId(int technologyId);
        void UpdateTraining(int trainingId,Training training);
        void DeleteTraining(int trainingId);

    }
}
