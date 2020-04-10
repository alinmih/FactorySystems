using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.CommonLibrary.ViewModels;
using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary.CompanyData
{
    public class PlantData : IPlantData
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

            var res = _db.SaveDataAsync<PlantModel, int>(procName, plant);

            return res;
        }

        /// <summary>
        /// Get all the plants from db based on plant object params
        /// </summary>
        /// <param name="plant">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns>List of plants VM</returns>
        public Task<List<PlantModel>> GetPlantList(PlantModel plant)
        {
            string procName = "Company.PlantSelect";

            var results = _db.LoadDataAsync<PlantModel, dynamic>(procName, plant);

            return results;
        }

        /// <summary>
        /// Update specific plant from db
        /// </summary>
        /// <param name="plant">Model to update</param>
        /// <returns></returns>
        public Task UpdatePlant(PlantModel plant)
        {
            string procName = "Company.PlantUpdate";

            return _db.UpdateDataAsync(procName, plant);
        }

        /// <summary>
        /// Delete a plant by id
        /// </summary>
        /// <param name="plantId">Id of the plant</param>
        /// <returns></returns>
        public Task DeletePlant(int plantId)
        {
            string procName = "Company.PlantDelete";

            return _db.DeleteDataAsync(procName, new { PlantId = plantId });
        }

    }
}
