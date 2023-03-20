using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplicationCronus;

namespace WebApplicationCronus.DAL
{
    public class DirectDbQueries
    {
        internal SqlConnection connection;

        public DirectDbQueries()
        {
            IConfigurationRoot configuration = MyConfigurationHelper.GetConfiguration();
            string connectionString = configuration.GetConnectionString("Assignment4Connection");
            connection = new SqlConnection(connectionString);
        }

        public string[] GetPK_ConstraintNamesFromDb()
        {
            var constraintNames = new List<string>();

            using (connection)
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT TABLE_NAME, CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tableName = reader.GetString(0);
                            var constraintName = reader.GetString(1);
                            constraintNames.Add($"Table = {tableName}, |       | PK Constraint = {constraintName}");
                        }
                    }
                }
            }
            return constraintNames.ToArray();     
        }
        public string[] GetAllColumnNamesFromDb()
        {
            var columnNames = new List<string>();

            using (connection)
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CRONUS Sverige AB$Item'", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnNames.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return columnNames.ToArray();
        }
        public string GetTotalTablesFromDb()
        {
            using (connection)
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT CAST(COUNT(*) AS VARCHAR) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", connection))
                {
                    var totalTables = command.ExecuteScalar().ToString();
                    return totalTables;
                }
            }
        }
        public string GetTotalColumnsFromDb()
        {
            var totalColumns = "";

            using (connection)
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT CAST(COUNT(*) AS VARCHAR) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'dbo'", connection))
                {
                    totalColumns = command.ExecuteScalar().ToString();
                }
            }
            return totalColumns;
        }
    }
}
