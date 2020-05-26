using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary.CompanyData
{
    public class OperatorGroupData : IOperatorGroupData
    {
        /// <summary>
        /// Reference to Sql data access layer
        /// </summary>
        private readonly IDataAccess _db;

        public OperatorGroupData(IDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Insert into DB a group object
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public Task<int> InsertOperatorGroup(OperatorGroupModel group)
        {
            string procName = "Company.OperatorGroupInsert";

            var res = _db.SaveDataAsync<OperatorGroupModel, int>(procName, group);

            return res;
        }

        /// <summary>
        /// Get all the groups from db based on group object params
        /// </summary>
        /// <param name="group">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns></returns>
        public Task<List<OperatorGroupModel>> GetOperatorGroupList(OperatorGroupModel group)
        {
            string procName = "Company.OperatorGroupSelect";

            return _db.GetDataAsync<OperatorGroupModel, dynamic>(procName, group);
        }

        /// <summary>
        /// Update specific group from db
        /// </summary>
        /// <param name="group">Model to update</param>
        /// <returns></returns>
        public Task UpdateOperatorGroup(OperatorGroupModel group)
        {
            string procName = "Company.OperatorGroupUpdate";

            return _db.UpdateDataAsync(procName, group);
        }

        /// <summary>
        /// Delete a group by id
        /// </summary>
        /// <param name="groupId">Id of the group</param>
        /// <returns></returns>
        public Task DeleteOperatorGroup(int groupId)
        {
            string procName = "Company.OperatorGroupDelete";

            return _db.DeleteDataAsync(procName, new { OperatorGroupId = groupId });
        }
    }
}
