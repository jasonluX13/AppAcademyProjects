using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Repositories
{
    public class WorkTypeRepository
    {
        public WorkTypeRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InvoiceMaker"].ConnectionString;
        }

        public List<WorkType> GetWorkTypes()
        {
            List<WorkType> workTypes = new List<WorkType>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
                  SELECT Id, WorkName, Rate
                  FROM WorkType
                  ORDER BY WorkName
                ";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    decimal rate = decimal.Round(reader.GetDecimal(2), 2);
                    WorkType workType = new WorkType(id, name, rate);
                    workTypes.Add(workType);
                }
            }
            return workTypes;
        }

        public WorkType GetById(int id)
        {
            WorkType workType;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
                  SELECT Id, WorkName, Rate
                  FROM WorkType
                  WHERE Id = @Id
                  ORDER BY WorkName
                ";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    
                    string name = reader.GetString(1);
                    decimal rate = decimal.Round(reader.GetDecimal(2),2);
                    workType = new WorkType(id, name, rate);
                    return workType;
                }


            }
            return null;

        }

        public void Insert(WorkType workType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
                  INSERT INTO WorkType(WorkName, Rate)
                  VALUES
                  (@workName, @rate)
                ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@workName", workType.Name);
                command.Parameters.AddWithValue("@rate", decimal.Round(workType.Rate,4));
                command.ExecuteNonQuery();
            }
        }

        public void Update(WorkType workType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
                  UPDATE WorkType
                  SET WorkName = @name
                    , Rate = @rate
                  WHERE Id = @id
                ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", workType.Name);
                command.Parameters.AddWithValue("@rate", workType.Rate);
                command.Parameters.AddWithValue("@id", workType.Id);
                command.ExecuteNonQuery();
            }
        }
        private string _connectionString;
    }
}