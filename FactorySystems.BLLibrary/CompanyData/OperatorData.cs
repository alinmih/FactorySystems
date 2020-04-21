using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary.CompanyData
{
    public class OperatorData : IOperatorData
    {
        /// <summary>
        /// Reference to Sql data access layer
        /// </summary>
        private readonly ISqlDataAccess _db;

        public OperatorData(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Insert into DB a operator object
        /// </summary>
        /// <param name="operatorModel"></param>
        /// <returns></returns>
        public Task<int> InsertOperator(OperatorModel operatorModel)
        {
            string procName = "Company.OperatorInsert";

            var res = _db.SaveDataAsync<OperatorModel, int>(procName, operatorModel);

            return res;
        }

        /// <summary>
        /// Get all the operators from db based on operator object params
        /// </summary>
        /// <param name="operatorModel">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns></returns>
        public Task<List<OperatorModel>> GetOperatorList(OperatorModel operatorModel)
        {
            string procName = "Company.OperatorSelect";

            return _db.LoadDataAsync<OperatorModel, dynamic>(procName, operatorModel);
        }

        /// <summary>
        /// Update specific operator from db
        /// </summary>
        /// <param name="operatorModel">Model to update</param>
        /// <returns></returns>
        public Task UpdateOperator(OperatorModel operatorModel)
        {
            string procName = "Company.OperatorUpdate";

            return _db.UpdateDataAsync(procName, operatorModel);
        }

        /// <summary>
        /// Delete a operator by id
        /// </summary>
        /// <param name="operatorId">Id of the operator</param>
        /// <returns></returns>
        public Task DeleteOperator(int operatorId)
        {
            string procName = "Company.OperatorDelete";

            return _db.DeleteDataAsync(procName, new { OperatorId = operatorId });
        }
    }
}
