using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOEmployeeRepository : IEmployeeRepository
    {
        SqlConnection conn;
        SqlCommand cmd;

        public ADOEmployeeRepository()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;database = ZelisTrainingDB;
integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
        public void AddEmployee(Employee employee)
        {
            cmd.CommandText = $"insert into Employee values({employee.EmpId},'{employee.EmpName}','{employee.Designation}','{employee.Email}','{employee.Phone}')";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteEmployee(int empId)
        {
            cmd.CommandText = $"delete from Employee where EmpID={empId}";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Employee> GetAllEmployees()
        {
            cmd.CommandText = $"select * from Employee";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {

                Employee employee = new Employee();
                employee.EmpId = (int)reader["EmpId"];
                employee.EmpName = (string)reader["EmpName"];
                employee.Designation = (string)reader["Designation"];
                employee.Email = (string)reader["Email"];
                employee.Phone = (string)reader["Phone"];
                
                employees.Add(employee);
            }
            conn.Close();
            return employees;
        }

        public Employee GetEmployeeById(int empId)
        {
            cmd.CommandText = $"select * from Employee where EmpId={empId}";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Employee employee = new Employee();
            if (reader.HasRows)
            {
                reader.Read();
                employee.EmpId = (int)reader["EmpId"];
                employee.EmpName = (string)reader["EmpName"];
                employee.Designation = (string)reader["Designation"];
                employee.Email = (string)reader["Email"];
                employee.Phone = (string)reader["Phone"];
                conn.Close();
                return employee;
            }
            else
            {
                conn.Close();
                throw new ZelisInstituteException("No such Employee id");
            }
        }

        public List<Employee> GetEmployeesByDesignation(string designation)
        {
            cmd.CommandText = $"select * from Employee where Designation='{designation}'";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {

                Employee employee = new Employee();
                employee.EmpId = (int)reader["EmpId"];
                employee.EmpName = (string)reader["EmpName"];
                employee.Designation = (string)reader["Designation"];
                employee.Email = (string)reader["Email"];
                employee.Phone = (string)reader["Phone"];

                employees.Add(employee);
            }
            conn.Close();
            return employees;
        }

        public void UpdateEmployee(int empId, Employee employee)
        {
            cmd.CommandText = $"update Employee set EmpName ='{employee.EmpName}',Designation='{employee.Designation}',Email='{employee.Email}',Phone='{employee.Phone}' where EmpId={empId}";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
