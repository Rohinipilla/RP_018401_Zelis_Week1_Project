using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTechnologyRepository : ITechnologyRepository
    {
        SqlConnection conn;
        SqlCommand cmd;
        public ADOTechnologyRepository()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;database = ZelisTrainingDB;
integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
        public void AddTechnology(Technology technology)
        {
            cmd.CommandText = $"insert into Technology values({technology.TechnologyId},'{technology.TechnologyName}','{technology.Level}','{technology.Duration}')";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteTechnology(int technologyId)
        {
            cmd.CommandText = $"delete from Technology where TechnologyId={technologyId}";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Technology> GetAllTechnologies()
        {
            cmd.CommandText = $"SELECT * FROM Technology";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Technology> technologies = new List<Technology>();

            while (reader.Read())
            {
                Technology tech = new Technology();
                tech.TechnologyId = (int)reader["TechnologyId"];
                tech.TechnologyName = (string)reader["TechnologyName"];
                tech.Level = (string)reader["Level"];
                tech.Duration = (int)reader["Duration"];

                technologies.Add(tech);
            }

            conn.Close();
            return technologies;
        }

        public List<Technology> GetTechnologiesByDuration(string duration)
        {
            cmd.CommandText = $"SELECT * FROM Technology where Duration={duration}";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Technology> technologies = new List<Technology>();

            while (reader.Read())
            {
                Technology tech = new Technology();
                tech.TechnologyId = (int)reader["TechnologyId"];
                tech.TechnologyName = (string)reader["TechnologyName"];
                tech.Level = (string)reader["Level"];
                tech.Duration = (int)reader["Duration"];

                technologies.Add(tech);
            }

            conn.Close();
            return technologies;
        }

        public List<Technology> GetTechnologiesByLevel(string level)
        {
            cmd.CommandText = "SELECT * FROM Technology WHERE Level = @level";
            cmd.Parameters.Clear(); 
            cmd.Parameters.AddWithValue("@level", level);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Technology> technologies = new List<Technology>();

            while (reader.Read())
            {
                Technology tech = new Technology();
                tech.TechnologyId = (int)reader["TechnologyId"];
                tech.TechnologyName = (string)reader["TechnologyName"];
                tech.Level = (string)reader["Level"];
                tech.Duration = (int)reader["Duration"];

                technologies.Add(tech);
            }

            conn.Close();
            return technologies;
        }

        public Technology GetTechnologyById(int technologyId)
        {
            cmd.CommandText = $"SELECT * FROM Technology WHERE TechnologyId = {technologyId}";
            
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Technology tech = new Technology();

            if (reader.Read())
            {
                
                tech.TechnologyId = (int)reader["TechnologyId"];
                tech.TechnologyName = (string)reader["TechnologyName"];
                tech.Level = (string)reader["Level"];
                tech.Duration = (int)reader["Duration"];
            }

            conn.Close();
            return tech;
        }

        public void UpdateTechnology(int technologyId, Technology technology)
        {
            cmd.CommandText = $"update Technology set TechnologyName='{technology.TechnologyName}',Level='{technology.Level}',Duration='{technology.Duration}' where TechnologyId={technologyId}";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
