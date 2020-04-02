using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using FactorySystems.CommonLibrary.PersistanceModels;

namespace FactorySystems.BLLibrary.CompanyData
{
    public class DepartmentData
    {
        /// <summary>
        /// Reference to Sql data access layer
        /// </summary>
        private readonly ISqlDataAccess _db;

        public DepartmentData(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Insert into DB a department object
        /// </summary>
        /// <param name="department">PersistenceModel send as param with default or specific props</param>
        /// <returns></returns>
        public Task<int> InsertDepartment(DepartmentModel department)
        {
            string procName = "Company.DepartmentInsert";

            var res = _db.SaveData<DepartmentModel, int>(procName, department);

            return res;
        }

        /// <summary>
        /// Get all the departments from db based on department object params
        /// </summary>
        /// <param name="plant">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns></returns>
        public Task<List<DepartmentModel>> GetDepartmentList(DepartmentModel department)
        {
            string procName = "Company.DepartmentSelect";

            return _db.LoadData<DepartmentModel, dynamic>(procName, department);
        }

        /// <summary>
        /// Update specific department from db
        /// </summary>
        /// <param name="department">Model to update</param>
        /// <returns></returns>
        public Task UpdateDepartment(DepartmentModel department)
        {
            string procName = "Company.DepartmentUpdate";

            return _db.UpdateData(procName, department);
        }

        /// <summary>
        /// Delete a department by id
        /// </summary>
        /// <param name="plantId">Id of the department</param>
        /// <returns></returns>
        public Task DeleteDepartment(int departmentId)
        {
            string procName = "Company.DepartmentDelete";

            return _db.DeleteData(procName, new { DepartmentId = departmentId });

        }
    }
}
