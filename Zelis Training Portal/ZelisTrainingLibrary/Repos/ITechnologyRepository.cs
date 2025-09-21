using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITechnologyRepository
    {
        void AddTechnology(Technology technology);
        Technology GetTechnologyById(int technologyId);
        List<Technology> GetAllTechnologies();
        List<Technology> GetTechnologiesByLevel(string level);
        List<Technology> GetTechnologiesByDuration(string duration);
        void UpdateTechnology(int technologyId,Technology technology);
        void DeleteTechnology(int technologyId);
    }
}
