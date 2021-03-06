﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FactorySystems.CommonLibrary.GlobalConfig;


namespace FactorySystems.DALibrary
{
    /// <summary>
    /// Generic class to get data from db
    /// </summary>
    public class DapperDataAccess : IDataAccess
    {
        //Get connection string from GlobalConfig static class
        private readonly string _connectionString;

        public DapperDataAccess()
        {
            _connectionString = GlobalConfig.ConnectionString;
        }


        /// <summary>
        /// Save data to database
        /// </summary>
        /// <typeparam name="U">Type of object to be passed</typeparam>
        /// <typeparam name="V">Return type</typeparam>
        /// <param name="procName">Name of the stored procedure</param>
        /// <param name="parameters">Object to be passed</param>
        /// <returns>Returns from db the id of the inserted object</returns>
        public async Task<V> SaveDataAsync<U, V>(string procName, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var p = new DynamicParameters();

                    // Get the prop data types, names, values and attr
                    var props = parameters.GetType().GetProperties()
                        .Select(pi => new { Name = pi.Name, Value = pi.GetValue(parameters), Attr = pi.CustomAttributes.Count() }).ToList();

                    string keyName = "";

                    // Add props to dynamic params, search for key param and set it as oupup param to get the id from sql
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

                    // Execute sql command
                    var data = await connection.ExecuteAsync(procName, p, commandType: CommandType.StoredProcedure);

                    // Get the id from inserted row
                    var id = p.Get<V>($"@{keyName}");

                    return id;

                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Load all the data from db table
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        /// <typeparam name="U">Type of object to be passed</typeparam>
        /// <param name="procName">Stored procedure name</param>
        /// <param name="parameters">Object param</param>
        /// <returns>List<T> object</returns>
        public async Task<List<T>> GetDataAsync<T, U>(string procName, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Execute sql command
                    var data = await connection.QueryAsync<T>(procName, parameters, commandType: CommandType.StoredProcedure);

                    return data.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Update one object by id from db
        /// </summary>
        /// <typeparam name="U">Type of object to be passed</typeparam>
        /// <param name="procName">Stored procedure name</param>
        /// <param name="parameters">Object param</param>
        /// <returns>Returns void</returns>
        public async Task UpdateDataAsync<U>(string procName, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Execute sql command
                    var data = await connection.ExecuteAsync(procName, parameters, commandType: CommandType.StoredProcedure);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Delete one object by id from db
        /// </summary>
        /// <typeparam name="U">Type of object to be passed</typeparam>
        /// <param name="procName">Stored procedure name</param>
        /// <param name="parameters">Object param</param>
        /// <returns>Returns void</returns>
        public async Task DeleteDataAsync<U>(string procName, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Execute sql command
                    var data = await connection.ExecuteAsync(procName, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
