using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Repositories
{
    public class WorkDoneRepository
    {
        public WorkDoneRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InvoiceMaker"].ConnectionString;
        }

        public List<WorkDone> GetAll()
        {
            List<WorkDone> workDones = new List<WorkDone>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
                    SELECT wd.Id, wd.ClientId, wd.WorkTypeId, wd.StartedOn,
                            wd.EndedOn, c.ClientName, c.IsActivated,
                            wt.WorkName, wt.Rate
                    FROM WorkDone AS wd
                    JOIN Client AS c ON (wd.ClientId = c.Id)
                    JOIN WorkType AS wt ON (wd.WorkTypeId = wt.Id)
                ";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int wdId = reader.GetInt32(0);
                    int wdClientId = reader.GetInt32(1);
                    int wdWorkTypeId = reader.GetInt32(2);
                    DateTimeOffset wdStartedOn = reader.GetDateTimeOffset(3);
                    DateTimeOffset? wdEndedOn = null;
                    if (!reader.IsDBNull(4))
                    {
                        wdEndedOn = reader.GetDateTimeOffset(4);
                    }
                    string cClientName = reader.GetString(5);
                    bool cIsActivated = reader.GetBoolean(6);
                    string wtWorkTypeName = reader.GetString(7);
                    decimal wtRate = reader.GetDecimal(8);
                    Client client = new Client(wdClientId, cClientName, cIsActivated);
                    WorkType workType = new WorkType(wdWorkTypeId, wtWorkTypeName, wtRate);

                    if (wdEndedOn.HasValue)
                    {
                        workDones.Add(new WorkDone(wdId, client, workType, wdStartedOn, wdEndedOn.Value));
                    }
                    else
                    {
                        workDones.Add(new WorkDone(wdId, client, workType, wdStartedOn));
                    }
                }
                return workDones;
            }
        }

        public void Insert(WorkDone workDone)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
                  INSERT INTO WorkDone(ClientId, WorkTypeId, StartedOn)
                  VALUES
                  (@ClientId, @WorkTypeId, @StartedOn)
                ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ClientId", workDone.GetClientId());
                command.Parameters.AddWithValue("@WorkTypeId", workDone.GetWorkTypeId());
                command.Parameters.AddWithValue("@StartedOn", workDone.StartedOn);
                //command.Parameters.AddWithValue("@EndedOn", workDone.EndedOn);
                command.ExecuteNonQuery();
            }
        }
        public void Update(WorkDone workDone)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
                  UPDATE WorkDone
                  SET ClientId = @clientId,
                  WorkTypeId = @workTypeId,
                  StartedOn = @startedOn,
                  EndedOn = @endedOn
                  WHERE Id = @id
                ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@clientId", workDone.GetClientId());
                command.Parameters.AddWithValue("@workTypeId", workDone.GetWorkTypeId());
                command.Parameters.AddWithValue("@startedOn", workDone.StartedOn);
                command.Parameters.AddWithValue("@endedOn", (object)workDone.EndedOn ?? DBNull.Value);
                command.Parameters.AddWithValue("@id", workDone.Id);
                command.ExecuteNonQuery();
            }
        }

        public WorkDone GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
                    SELECT wd.Id, wd.ClientId, wd.WorkTypeId, wd.StartedOn,
                            wd.EndedOn, c.ClientName, c.IsActivated,
                            wt.WorkName, wt.Rate
                    FROM WorkDone AS wd
                    JOIN Client AS c ON (wd.ClientId = c.Id)
                    JOIN WorkType AS wt ON (wd.WorkTypeId = wt.Id)
                    WHERE wd.Id = @id
                ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int wdId = reader.GetInt32(0);
                    int wdClientId = reader.GetInt32(1);
                    int wdWorkTypeId = reader.GetInt32(2);
                    DateTimeOffset wdStartedOn = reader.GetDateTimeOffset(3);
                    DateTimeOffset? wdEndedOn = null;
                    if (!reader.IsDBNull(4))
                    {
                        wdEndedOn = reader.GetDateTimeOffset(4);
                    }
                    string cClientName = reader.GetString(5);
                    bool cIsActivated = reader.GetBoolean(6);
                    string wtWorkTypeName = reader.GetString(7);
                    decimal wtRate = reader.GetDecimal(8);
                    Client client = new Client(wdClientId, cClientName, cIsActivated);
                    WorkType workType = new WorkType(wdWorkTypeId, wtWorkTypeName, wtRate);

                    if (wdEndedOn.HasValue)
                    {
                        return new WorkDone(wdId, client, workType, wdStartedOn, wdEndedOn.Value);
                    }
                    else
                    {
                        return new WorkDone(wdId, client, workType, wdStartedOn);
                    }
                }
            }
            return null;
        }

        private string _connectionString;
    }
}