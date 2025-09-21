using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITraineeRepository
    {
        void AddTrainee(Trainee trainee);
        Trainee GetTrainee(int trainingId, int empId);
        List<Trainee> GetAllTrainees();
        List<Trainee> GetTraineesByTrainingId(int trainingId);
        List<Trainee> GetTraineesByEmpId(int empId);
        List<Trainee> GetTraineesByStatus(string status);
        void UpdateTraineeStatus(int trainingId, int empId, char status);
        void DeleteTrainee(int trainingId, int empId);
    }
}
