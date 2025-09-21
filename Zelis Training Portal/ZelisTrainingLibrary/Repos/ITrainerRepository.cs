using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITrainerRepository
    {
        void AddTrainer(Trainer trainer);
        Trainer GetTrainerById(int trainerId);
        List<Trainer> GetAllTrainers();

        List<Trainer> GetTrainersByType(string  type);
        void UpdateTrainer(int trainerId,Trainer trainer);
        void DeleteTrainer(int trainerId);
    }
}
