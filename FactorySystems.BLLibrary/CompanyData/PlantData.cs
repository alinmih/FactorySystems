using FactorySystems.CommonLibrary.Adapters;
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
        private readonly IDataAccess _db;
        private readonly IAdapter _adapter;

        public PlantData(IDataAccess db, IAdapter adapter)
        {
            _db = db;
            _adapter = adapter;
        }

        /// <summary>
        /// Insert into DB a plant object
        /// </summary>
        /// <param name="plant">Persistence model</param>
        /// <returns></returns>
        internal Task<int> InsertPlant(PlantModel plant)
        {
            string procName = "Company.PlantInsert";

            var res = _db.SaveDataAsync<PlantModel, int>(procName, plant);

            return res;
        }

        /// <summary>
        /// Insert into DB a plant object
        /// </summary>
        /// <param name="plant">View model</param>
        /// <returns></returns>
        public Task<int> InsertPlant(PlantVM plant)
        {
            return InsertPlant(_adapter.ConvertToTFromU<PlantModel, PlantVM>(plant));
        }

        /// <summary>
        /// Get all the plants from db based on plant object params
        /// </summary>
        /// <param name="plant">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns>List of plants VM</returns>
        internal Task<List<PlantModel>> GetPlantList(PlantModel plant)
        {
            string procName = "Company.PlantSelect";

            var results = _db.GetDataAsync<PlantModel, dynamic>(procName, plant);

            return results;
        }


        /// <summary>
        /// Get all the plants from db based on plant object params
        /// </summary>
        /// <param name="plant">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns>List of plants model</returns>
        internal Task<List<PlantModel>> GetPlantList()
        {
            PlantModel plant = new PlantModel();
            string procName = "Company.PlantSelect";

            var results = _db.GetDataAsync<PlantModel, dynamic>(procName, plant);

            return results;
        }
        /// <summary>
        /// Get all the plants from db
        /// </summary>
        /// <returns>List of plants VM</returns>
        public async Task<List<PlantVM>> GetPlants()
        {
            var plants = _adapter.ConvertToTListFromU<PlantVM, PlantModel>(await GetPlantList());

            return plants;
        }
        /// <summary>
        /// Get all the plants from db based on plant object params
        /// </summary>
        /// <param name="plant">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns>List of plants VM</returns>
        public async Task<List<PlantVM>> GetPlants(PlantVM plant)
        {
            var plants = _adapter.ConvertToTListFromU<PlantVM, PlantModel>(await GetPlantList(_adapter.ConvertToTFromU<PlantModel, PlantVM>(plant)));

            return plants;
        }


        /// <summary>
        /// Update specific plant from db
        /// </summary>
        /// <param name="plant">PlantModel</param>
        /// <returns></returns>
        internal Task UpdatePlant(PlantModel plant)
        {
            string procName = "Company.PlantUpdate";

            return _db.UpdateDataAsync(procName, plant);
        }

        /// <summary>
        /// Update specific PlantModel from db
        /// </summary>
        /// <param name="plant">PlantVM</param>
        /// <returns></returns>
        public Task UpdatePlant(PlantVM plant)
        {
            return UpdatePlant(_adapter.ConvertToTFromU<PlantModel, PlantVM>(plant));
        }

        /// <summary>
        /// Delete a plant by id
        /// </summary>
        /// <param name="plantId">Id of the plant</param>
        /// <returns></returns>
        public Task DeletePlant(int plantId)
        {
            var del = Delete(plantId);

            return del;
        }

        internal Task Delete(int plantId)
        {
            string procName = "Company.PlantDelete";

            return _db.DeleteDataAsync(procName, new { PlantId = plantId });
        }

    }
}
