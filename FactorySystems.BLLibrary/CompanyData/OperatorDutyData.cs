using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary.CompanyData
{
    public class OperatorDutyData : IOperatorDutyData
    {
        /// <summary>
        /// Reference to Sql data access layer
        /// </summary>
        private readonly ISqlDataAccess _db;

        public OperatorDutyData(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Insert into DB a duty object
        /// </summary>
        /// <param name="duty"></param>
        /// <returns></returns>
        public Task<int> InsertOperatorDuty(OperatorDutyModel duty)
        {
            string procName = "Company.OperatorDutyInsert";

            var res = _db.SaveDataAsync<OperatorDutyModel, int>(procName, duty);

            return res;
        }

        /// <summary>
        /// Get all the duties from db based on duty object params
        /// </summary>
        /// <param name="duty">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns></returns>
        public Task<List<OperatorDutyModel>> GetOperatorDutyList(OperatorDutyModel duty)
        {
            string procName = "Company.OperatorDutySelect";

            return _db.LoadDataAsync<OperatorDutyModel, dynamic>(procName, duty);
        }

        /// <summary>
        /// Update specific duty from db
        /// </summary>
        /// <param name="duty">Model to update</param>
        /// <returns></returns>
        public Task UpdateOperatorDuty(OperatorDutyModel duty)
        {
            string procName = "Company.OperatorDutyUpdate";

            return _db.UpdateDataAsync(procName, duty);
        }

        /// <summary>
        /// Delete a duty by id
        /// </summary>
        /// <param name="dutyId">Id of the duty</param>
        /// <returns></returns>
        public Task DeleteOperatorDuty(int dutyId)
        {
            string procName = "Company.OperatorDutyDelete";

            return _db.DeleteDataAsync(procName, new { DutyId = dutyId });
        }
    }
}
