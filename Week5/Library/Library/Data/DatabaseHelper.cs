﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library.Data
{
    public static class DatabaseHelper
    {
        public static DataTable Retrieve(string sql, params SqlParameter[] parameters)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;

            DataTable dt = new DataTable();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sql, connection);

                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                var dataAdapter = new SqlDataAdapter(command);

                // This is where the work is happening.
                dataAdapter.Fill(dt);
            }

            return dt;
        }

        public static int? Insert(string sql, params SqlParameter[] parameters)
        {
            sql += @"
                select cast(scope_identity() as int) as 'id';
            ";

            string connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;

            int? id = null;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sql, connection);

                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                // This is where the work is happening.
                command.Connection.Open();
                id = (int?)command.ExecuteScalar();
            }

            return id;
        }

        public static void Update(string sql, params SqlParameter[] parameters)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sql, connection);

                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                // This is where the work is happening.
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
