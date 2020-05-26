using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary.CompanyData
{
    public class MachineData : IMachineData
    {
        /// <summary>
        /// Reference to Sql data access layer
        /// </summary>
        private readonly IDataAccess _db;

        public MachineData(IDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Insert into DB a Machine object
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        public Task<int> InsertMachine(MachineModel machine)
        {
            string procName = "Company.MachineInsert";

            var res = _db.SaveDataAsync<MachineModel, int>(procName, machine);

            return res;
        }

        /// <summary>
        /// Get all the machines from db based on machine object params
        /// </summary>
        /// <param name="machine">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns></returns>
        public Task<List<MachineModel>> GetMachineList(MachineModel machine)
        {
            string procName = "Company.MachineSelect";

            return _db.GetDataAsync<MachineModel, dynamic>(procName, machine);
        }

        /// <summary>
        /// Update specific machine from db
        /// </summary>
        /// <param name="machine">Model to update</param>
        /// <returns></returns>
        public Task UpdateMachine(MachineModel machine)
        {
            string procName = "Company.MachineUpdate";

            return _db.UpdateDataAsync(procName, machine);
        }

        /// <summary>
        /// Delete a machine by id
        /// </summary>
        /// <param name="machineId">Id of the machine</param>
        /// <returns></returns>
        public Task DeleteMachine(int machineId)
        {
            string procName = "Company.MachineDelete";

            return _db.DeleteDataAsync(procName, new { MachineId = machineId });
        }
    }
}
