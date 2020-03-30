using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactorySystems.DALibrary
{
    /// <summary>
    /// Type of database implemented
    /// </summary>
    public enum DatabaseAccesType
    {
        Dapper
    }

    public static class GlobalConfig
    {
        // Connection string name
        private static string connName = "Default";

        // Get connection string from app.settings.json
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsetings.json", optional: true, reloadOnChange: true);

            return builder.Build().GetSection("ConnectionStrings").GetSection(connName).Value;
        }

        // Reference to type of connection
        public static ISqlDataAccess Connection { get; private set; }

        /// <summary>
        /// Initialize connection with DB
        /// </summary>
        /// <param name="databaseAccesType">Enum type of DB</param>
        public static void InitializeConnection(DatabaseAccesType databaseAccesType)
        {
            if (databaseAccesType == DatabaseAccesType.Dapper)
            {
                SqlDataAccess dataAccess = new SqlDataAccess();
                Connection = dataAccess;
            }
        }
    }
}
