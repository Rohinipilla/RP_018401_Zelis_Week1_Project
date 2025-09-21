using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTrainerRepository:ITrainerRepository
    {
        SqlConnection conn;
        SqlCommand cmd;
        public ADOTrainerRepository()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;database = ZelisTrainingDB;
integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        public void AddTrainer(Trainer trainer)
        {
            cmd.CommandText = @"INSERT INTO Trainer (TrainerId,TrainerName, Type, Email, Phone)
                        VALUES (@TrainerId,@TrainerName, @Type, @Email, @Phone)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainerId", trainer.TrainerId);
            cmd.Parameters.AddWithValue("@TrainerName", trainer.TrainerName);
            cmd.Parameters.AddWithValue("@Type", trainer.Type);
            cmd.Parameters.AddWithValue("@Email", trainer.Email);
            cmd.Parameters.AddWithValue("@Phone", trainer.Phone);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteTrainer(int trainerId)
        {
            cmd.CommandText = $"DELETE FROM Trainer WHERE TrainerId = @TrainerId";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainerId", trainerId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Trainer> GetAllTrainers()
        {
            cmd.CommandText = $"SELECT * FROM Trainer";

            cmd.Parameters.Clear();

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Trainer> trainers = new List<Trainer>();

            while (reader.Read())
            {
                Trainer trainer = new Trainer();
                trainer.TrainerId = (int)reader["TrainerId"];
                trainer.TrainerName = (string)reader["TrainerName"];
                trainer.Type = (string)reader["Type"];
                trainer.Email = (string)reader["Email"];
                trainer.Phone = (string)reader["Phone"];

                trainers.Add(trainer);
            }

            conn.Close();
            return trainers;
        }

        public Trainer GetTrainerById(int trainerId)
        {
            cmd.CommandText = $"SELECT * FROM Trainer WHERE TrainerId = @TrainerId";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TrainerId", trainerId);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Trainer trainer = new Trainer();

            if (reader.Read())
            {
                trainer.TrainerId = (int)reader["TrainerId"];
                trainer.TrainerName = (string)reader["TrainerName"];
                trainer.Type = (string)reader["Type"];
                trainer.Email = (string)reader["Email"];
                trainer.Phone = (string)reader["Phone"];
            }

            conn.Close();
            return trainer;
        }

        public List<Trainer> GetTrainersByType(string type)
        {
            cmd.CommandText = $"SELECT * FROM Trainer WHERE Type = @Type";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Type", type);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Trainer> trainers = new List<Trainer>();

            while (reader.Read())
            {
                Trainer trainer = new Trainer();
                trainer.TrainerId = (int)reader["TrainerId"];
                trainer.TrainerName = (string)reader["TrainerName"];
                trainer.Type = (string)reader["Type"];
                trainer.Email = (string)reader["Email"];
                trainer.Phone = (string)reader["Phone"];

                trainers.Add(trainer);
            }

            conn.Close();
            return trainers;
        }

        public void UpdateTrainer(int trainerId,Trainer trainer)
        {

            cmd.CommandText = $"update Trainer set TrainerName ='{trainer.TrainerName}',Type='{trainer.Type}',Email='{trainer.Email}',Phone='{trainer.Phone}' where TrainerId={trainerId}";

            conn.Open();
           

            cmd.ExecuteNonQuery();
            conn.Close();


        }
    }
}
