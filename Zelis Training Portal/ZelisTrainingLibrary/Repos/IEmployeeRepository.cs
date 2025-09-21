using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        Employee GetEmployeeById(int empId);
        List<Employee> GetAllEmployees();

        List<Employee> GetEmployeesByDesignation(string designation);
        void UpdateEmployee(int empId,Employee employee);
        void DeleteEmployee(int empId);
    }
}
