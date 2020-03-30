﻿using FactorySystems.CommonLibrary.Models;
using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary
{
    public class PlantData
    {
        /// <summary>
        /// Reference to Sql data access layer
        /// </summary>
        private readonly ISqlDataAccess _db;

        public PlantData(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Insert into DB a plant object
        /// </summary>
        /// <param name="plant"></param>
        /// <returns></returns>
        public Task<int> InsertPlant(PlantModel plant)
        {
            string procName = "Company.PlantInsert";

            var res = _db.SaveData<PlantModel, int>(procName, plant);

            return res;
        }

        ///// <summary>
        ///// Get plant object by Id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public Task<PlantModel> GetPlantById(int id)
        //{
        //    string procName = "Company.PlantSelectById";

        //    return _db.LoadDataById<PlantModel, dynamic>(procName, new { PlantId = id });
        //}

        /// <summary>
        /// Get all the plants from db based on plant object params
        /// </summary>
        /// <param name="plant">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns></returns>
        public Task<List<PlantModel>> GetPlantList(PlantModel plant)
        {
            string procName = "Company.PlantSelect";

            return _db.LoadData<PlantModel, dynamic>(procName, new
            {
                plant.Name,
                plant.Address,
                plant.City,
                plant.Phone,
                plant.Email
            });
        }
        
        /// <summary>
        /// Update specific plant from db
        /// </summary>
        /// <param name="plant">Model to update</param>
        /// <returns></returns>
        public Task UpdatePlant(PlantModel plant)
        {
            string procName = "Company.PlantUpdate";

            return _db.UpdateData(procName, plant);
        }

        /// <summary>
        /// Delete a plant by id
        /// </summary>
        /// <param name="plantId">Id of the plant</param>
        /// <returns></returns>
        public Task DeletePlant(int plantId)
        {
            string procName = "Company.PlantDelete";

            return _db.DeleteData(procName, new { PlantId = plantId });
        }

    }
}