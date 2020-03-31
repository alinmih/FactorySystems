using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FactorySystems.DALibrary
{
    /// <summary>
    /// Generic class to get data from db
    /// </summary>
    public class SqlDataAccess : ISqlDataAccess
    {
        //Get connection string from GlobalConfig static class
        private readonly string connectionString = GlobalConfig.GetConnectionString();

        public SqlDataAccess()
        {
        }

        /// <summary>
        /// Save data to database
        /// </summary>
        /// <typeparam name="U">Type of object to be passed</typeparam>
        /// <typeparam name="V">Return type</typeparam>
        /// <param name="procName">Name of the stored procedure</param>
        /// <param name="parameters">Object to be passed</param>
        /// <returns>Returns from db the id of the inserted object</returns>
        public async Task<V> SaveData<U, V>(string procName, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var p = new DynamicParameters();

                var props = parameters.GetType().GetProperties()
                    .Select(pi => new { Name = pi.Name, Value = pi.GetValue(parameters), Attr = pi.CustomAttributes.Count() }).ToList();

                string keyName = "";

                foreach (var item in props)
                {
                    if (item.Attr == 1)
                    {
                        p.Add($"@{item.Name}", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                        keyName = item.Name;
                        continue;
                    }
                    p.Add($"@{item.Name}", item.Value);
                }

                var data = await connection.ExecuteAsync(procName, p, commandType: CommandType.StoredProcedure);

                var id = p.Get<V>($"@{keyName}");

                return id;
            }
        }

        ///// <summary>
        ///// Load one object by id from db
        ///// </summary>
        ///// <typeparam name="T">Type of object to return</typeparam>
        ///// <typeparam name="U">Type of object to be passed</typeparam>
        ///// <param name="procName">Stored procedure name</param>
        ///// <param name="parameters">Object param</param>
        ///// <returns>Object T</returns>
        //public async Task<T> LoadDataById<T, U>(string procName, U parameters)
        //{
        //    using (IDbConnection connection = new SqlConnection(connectionString))
        //    {
        //        var data = await connection.QueryFirstAsync<T>(procName, parameters, commandType: CommandType.StoredProcedure);

        //        return data;
        //    }
        //}

        /// <summary>
        /// Load all the data from db table
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        /// <typeparam name="U">Type of object to be passed</typeparam>
        /// <param name="procName">Stored procedure name</param>
        /// <param name="parameters">Object param</param>
        /// <returns>List<T> object</returns>
        public async Task<List<T>> LoadData<T, U>(string procName, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(procName, parameters, commandType: CommandType.StoredProcedure);

                return data.ToList();
            }
        }

        /// <summary>
        /// Update one object by id from db
        /// </summary>
        /// <typeparam name="U">Type of object to be passed</typeparam>
        /// <param name="procName">Stored procedure name</param>
        /// <param name="parameters">Object param</param>
        /// <returns>Returns void</returns>
        public async Task UpdateData<U>(string procName, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.ExecuteAsync(procName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Delete one object by id from db
        /// </summary>
        /// <typeparam name="U">Type of object to be passed</typeparam>
        /// <param name="procName">Stored procedure name</param>
        /// <param name="parameters">Object param</param>
        /// <returns>Returns void</returns>
        public async Task DeleteData<U>(string procName, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.ExecuteAsync(procName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
