
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTrainingRepository : ITrainingRepository
    {
        SqlConnection conn;
        SqlCommand cmd;
        public ADOTrainingRepository()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;database = ZelisTrainingDB;
integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
        public void AddTraining(Training training)
        {
            cmd.CommandText = @"INSERT INTO Training (TrainingId,TrainerId, TechnologyId, StartDate, EndDate)
                        VALUES (@TrainingId,@TrainerId, @TechnologyId, @StartDate, @EndDate)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainingId", training.TrainingId);
            cmd.Parameters.AddWithValue("@TrainerId", training.TrainerId);
            cmd.Parameters.AddWithValue("@TechnologyId", training.TechnologyId);
            cmd.Parameters.AddWithValue("@StartDate", training.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", training.EndDate);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteTraining(int trainingId)
        {
            cmd.CommandText = @"DELETE FROM Training WHERE TrainingId = @TrainingId";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainingId", trainingId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Training> GetAllTrainings()
        {
            cmd.CommandText = $"SELECT * FROM Training";

            cmd.Parameters.Clear();

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Training> trainings = new List<Training>();

            while (reader.Read())
            {
                Training training = new Training();
                training.TrainingId = (int)reader["TrainingId"];
                training.TrainerId = (int)reader["TrainerId"];
                training.TechnologyId = (int)reader["TechnologyId"];
                training.StartDate = (DateTime)reader["StartDate"];
                training.EndDate = (DateTime)reader["EndDate"];

                trainings.Add(training);
            }

            conn.Close();
            return trainings;
        }

        public Training GetTrainingById(int trainingId)
        {
            cmd.CommandText = $"SELECT * FROM Training WHERE TrainingId = @TrainingId";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainingId", trainingId);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Training training = new Training();

            if (reader.Read())
            {
                training.TrainingId = (int)reader["TrainingId"];
                training.TrainerId = (int)reader["TrainerId"];
                training.TechnologyId = (int)reader["TechnologyId"];
                training.StartDate = (DateTime)reader["StartDate"];
                training.EndDate = (DateTime)reader["EndDate"];
            }

            conn.Close();
            return training;
        }

        public List<Training> GetTrainingsByTechnologyId(int technologyId)
        {
            cmd.CommandText = $"SELECT * FROM Training WHERE TechnologyId = @TechnologyId";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TechnologyId", technologyId);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Training> trainings = new List<Training>();

            while (reader.Read())
            {
                Training training = new Training();
                training.TrainingId = (int)reader["TrainingId"];
                training.TrainerId = (int)reader["TrainerId"];
                training.TechnologyId = (int)reader["TechnologyId"];
                training.StartDate = (DateTime)reader["StartDate"];
                training.EndDate = (DateTime)reader["EndDate"];

                trainings.Add(training);
            }

            conn.Close();
            return trainings;
        }

        public List<Training> GetTrainingsByTrainerId(int trainerId)
        {
            cmd.CommandText = $"SELECT * FROM Training WHERE TrainerId = @TrainerId";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainerId", trainerId);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Training> trainings = new List<Training>();

            while (reader.Read())
            {
                Training training = new Training();
                training.TrainingId = (int)reader["TrainingId"];
                training.TrainerId = (int)reader["TrainerId"];
                training.TechnologyId = (int)reader["TechnologyId"];
                training.StartDate = (DateTime)reader["StartDate"];
                training.EndDate = (DateTime)reader["EndDate"];

                trainings.Add(training);
            }

            conn.Close();
            return trainings;
        }

        public void UpdateTraining(int trainingId,Training training)
        {
            cmd.CommandText = @"UPDATE Training 
                        SET TrainerId = @TrainerId,
                            TechnologyId = @TechnologyId,
                            StartDate = @StartDate,
                            EndDate = @EndDate
                        WHERE TrainingId = @TrainingId";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainerId", training.TrainerId);
            cmd.Parameters.AddWithValue("@TechnologyId", training.TechnologyId);
            cmd.Parameters.AddWithValue("@StartDate", training.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", training.EndDate);
            cmd.Parameters.AddWithValue("@TrainingId", trainingId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
