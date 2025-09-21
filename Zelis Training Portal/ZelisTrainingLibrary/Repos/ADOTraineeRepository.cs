using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTraineeRepository : ITraineeRepository
    {
        SqlConnection conn;
        SqlCommand cmd;
        public ADOTraineeRepository()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;database = ZelisTrainingDB;
integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
        public void AddTrainee(Trainee trainee)
        {
            cmd.CommandText = @"INSERT INTO Trainee (TrainingId, EmpId, Status) 
                        VALUES (@TrainingId, @EmpId, @Status)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainingId", trainee.TrainingId);
            cmd.Parameters.AddWithValue("@EmpId", trainee.EmpId);
            cmd.Parameters.AddWithValue("@Status", trainee.Status);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteTrainee(int trainingId, int empId)
        {
            cmd.CommandText = "DELETE FROM Trainee WHERE TrainingId = @TrainingId AND EmpId = @EmpId";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainingId", trainingId);
            cmd.Parameters.AddWithValue("@EmpId", empId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Trainee GetTrainee(int trainingId, int empId)
        {
            cmd.CommandText = "SELECT * FROM Trainee WHERE TrainingId = @TrainingId AND EmpId = @EmpId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainingId", trainingId);
            cmd.Parameters.AddWithValue("@EmpId", empId);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Trainee trainee = new Trainee();
            if (reader.Read())
            {

                trainee.TrainingId = (int)reader["TrainingId"];
                trainee.EmpId = (int)reader["EmpId"];
                trainee.Status = (string)reader["Status"];
                
            }

            conn.Close();
            return trainee;
        }
        public List<Trainee> GetAllTrainees()
        {
            cmd.CommandText = "SELECT * FROM Trainee";

            List<Trainee> trainees = new List<Trainee>();

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            

            while (reader.Read())
            {
                Trainee trainee = new Trainee();
                trainee.TrainingId = (int)reader["TrainingId"];
                trainee.EmpId = (int)reader["EmpId"];
                trainee.Status = (string)reader["Status"];
                trainees.Add(trainee);
            }
            conn.Close();
            return trainees;

        }

        public List<Trainee> GetTraineesByEmpId(int empId)
        {
            cmd.CommandText = "SELECT * FROM Trainee WHERE EmpId = @EmpId";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@EmpId", empId);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Trainee> trainees = new List<Trainee>();

            while (reader.Read())
            {
                Trainee trainee = new Trainee();
                trainee.TrainingId = (int)reader["TrainingId"];
                trainee.EmpId = (int)reader["EmpId"];
                trainee.Status = (string)reader["Status"];
                trainees.Add(trainee);
            }

            conn.Close();
            return trainees;
        }

        public List<Trainee> GetTraineesByStatus(string status)
        {
            cmd.CommandText = "SELECT * FROM Trainee WHERE Status = @Status";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Status", status);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Trainee> trainees = new List<Trainee>();

            while (reader.Read())
            {
                Trainee trainee = new Trainee();
                trainee.TrainingId = (int)reader["TrainingId"];
                trainee.EmpId = (int)reader["EmpId"];
                trainee.Status = (string)reader["Status"];
                trainees.Add(trainee);
            }

            conn.Close();
            return trainees;
        }

        public List<Trainee> GetTraineesByTrainingId(int trainingId)
        {
            cmd.CommandText = "SELECT * FROM Trainee WHERE TrainingId = @TrainingId";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainingId", trainingId);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Trainee> trainees = new List<Trainee>();

            while (reader.Read())
            {
                Trainee trainee = new Trainee();
                trainee.TrainingId = (int)reader["TrainingId"];
                trainee.EmpId = (int)reader["EmpId"];
                trainee.Status = (string)reader["Status"];
                trainees.Add(trainee);
            }

            conn.Close();
            return trainees;
        }

        public void UpdateTraineeStatus(int trainingId, int empId, char status)
        {
            cmd.CommandText = @"UPDATE Trainee 
                        SET Status = @Status 
                        WHERE TrainingId = @TrainingId AND EmpId = @EmpId";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Status", status.ToString()); 
            cmd.Parameters.AddWithValue("@TrainingId", trainingId);
            cmd.Parameters.AddWithValue("@EmpId", empId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
