using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Repositories
{
    public class WorkLineItemRepository
    {
        public WorkLineItemRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InvoiceMaker"].ConnectionString;
        }

        public List<WorkLineItem> GetWorkLineItems()
        {
            List<WorkLineItem> workLineItems = new List<WorkLineItem>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
                  SELECT Id, WorkDoneId
                  FROM WorkLineItem
                  ORDER BY Id
                ";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int workDoneId = reader.GetInt32(1);
                    WorkDone wd = new WorkDoneRepository().GetById(workDoneId);
                    WorkLineItem wli = new WorkLineItem(id, wd);
                    workLineItems.Add(wli);
                }
            }
            return workLineItems;
        }


        private string _connectionString;
    }
}