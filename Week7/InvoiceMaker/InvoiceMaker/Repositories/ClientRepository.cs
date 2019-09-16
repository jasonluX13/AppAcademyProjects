using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Repositories
{
    public class ClientRepository
    {
        public ClientRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InvoiceMaker"].ConnectionString;
        }

        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
                  SELECT Id, ClientName, IsActivated
                  FROM Client
                  ORDER BY ClientName
                ";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    bool isActivated = reader.GetBoolean(2);
                    Client client = new Client(id, name, isActivated);
                    clients.Add(client);
                }
            }
            return clients;
        }

        private string _connectionString;
    }
}
