using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary.CompanyData
{
    public class CostCenterData : ICostCenterData
    {
        /// <summary>
        /// Reference to Sql data access layer
        /// </summary>
        private readonly ISqlDataAccess _db;

        public CostCenterData(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Insert into DB a department object
        /// </summary>
        /// <param name="costCenter"></param>
        /// <returns></returns>
        public Task<int> InsertCostCenter(CostCenterModel costCenter)
        {
            string procName = "Company.CostCenterInsert";

            var res = _db.SaveDataAsync<CostCenterModel, int>(procName, costCenter);

            return res;
        }

        /// <summary>
        /// Get all the costcenters from db based on costcenter object params
        /// </summary>
        /// <param name="costCenter">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns></returns>
        public Task<List<CostCenterModel>> GetCostCenterList(CostCenterModel costCenter)
        {
            string procName = "Company.CostCenterSelect";

            return _db.LoadDataAsync<CostCenterModel, dynamic>(procName, costCenter);
        }

        /// <summary>
        /// Update specific department from db
        /// </summary>
        /// <param name="costCenter">Model to update</param>
        /// <returns></returns>
        public Task UpdateCostCenter(CostCenterModel costCenter)
        {
            string procName = "Company.CostCenterUpdate";

            return _db.UpdateDataAsync(procName, costCenter);
        }

        /// <summary>
        /// Delete a department by id
        /// </summary>
        /// <param name="costCenterId">Id of the department</param>
        /// <returns></returns>
        public Task DeleteCostCenter(int costCenterId)
        {
            string procName = "Company.CostCenterDelete";

            return _db.DeleteDataAsync(procName, new { CostCenterId = costCenterId });
        }
    }
}
