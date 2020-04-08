using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary.CompanyData
{
    public class MachineStatusData
    {
        /// <summary>
        /// Reference to Sql data access layer
        /// </summary>
        private readonly ISqlDataAccess _db;

        public MachineStatusData(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Insert into DB a status object
        /// </summary>
        /// <param name="machineStatus">Model to insert</param>
        /// <returns></returns>
        public Task<int> InsertMachineStatus(MachineStatusModel machineStatus)
        {
            string procName = "Company.MachineStatusInsert";

            var res = _db.SaveDataAsync<MachineStatusModel, int>(procName, machineStatus);

            return res;
        }

        /// <summary>
        /// Get all the statuses from db based on MachineStatus object params
        /// </summary>
        /// <param name="machineStatus">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns></returns>
        public Task<List<MachineStatusModel>> GetMachineStatusList(MachineStatusModel machineStatus)
        {
            string procName = "Company.MachineStatusSelect";

            return _db.LoadDataAsync<MachineStatusModel, dynamic>(procName, machineStatus);
        }

        /// <summary>
        /// Update specific status from db
        /// </summary>
        /// <param name="machineStatus">Model to update</param>
        /// <returns></returns>
        public Task UpdateMachineStatus(MachineStatusModel machineStatus)
        {
            string procName = "Company.MachineStatusUpdate";

            return _db.UpdateDataAsync(procName, machineStatus);
        }

        /// <summary>
        /// Delete a status by id
        /// </summary>
        /// <param name="machineStatusId">Id of the status</param>
        /// <returns></returns>
        public Task DeleteMachineStatus(int machineStatusId)
        {
            string procName = "Company.MachineStatusDelete";

            return _db.DeleteDataAsync(procName, new { MachineStatusId = machineStatusId });
        }
    }
}
