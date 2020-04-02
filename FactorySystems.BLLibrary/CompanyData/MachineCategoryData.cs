using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary.CompanyData
{
    public class MachineCategoryData
    {
        /// <summary>
        /// Reference to Sql data access layer
        /// </summary>
        private readonly ISqlDataAccess _db;

        public MachineCategoryData(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Insert into DB a category object
        /// </summary>
        /// <param name="machineCategory"></param>
        /// <returns></returns>
        public Task<int> InsertMachineCategory(MachineCategoryModel machineCategory)
        {
            string procName = "Company.MachineCategoryInsert";

            var res = _db.SaveData<MachineCategoryModel, int>(procName, machineCategory);

            return res;
        }

        /// <summary>
        /// Get all the categories from db based on category object params
        /// </summary>
        /// <param name="machineCategory">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns></returns>
        public Task<List<MachineCategoryModel>> GetMachineCategoryList(MachineCategoryModel machineCategory)
        {
            string procName = "Company.MachineCategorySelect";

            return _db.LoadData<MachineCategoryModel, dynamic>(procName, machineCategory);
        }

        /// <summary>
        /// Update specific category from db
        /// </summary>
        /// <param name="machineCategory">Model to update</param>
        /// <returns></returns>
        public Task UpdateMachineCategory(MachineCategoryModel machineCategory)
        {
            string procName = "Company.MachineCategoryUpdate";

            return _db.UpdateData(procName, machineCategory);
        }

        /// <summary>
        /// Delete a category by id
        /// </summary>
        /// <param name="machineCategoryId">Id of the category</param>
        /// <returns></returns>
        public Task DeleteMachineCategory(int machineCategoryId)
        {
            string procName = "Company.MachineCategoryDelete";

            return _db.DeleteData(procName, new { MachineCategoryId = machineCategoryId });
        }
    }
}
