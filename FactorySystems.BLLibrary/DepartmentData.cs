using FactorySystems.CommonLibrary.Models;
using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary
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
        /// <param name="department"></param>
        /// <returns></returns>
        public Task<int> InsertDepartment(DepartmentModel department)
        {
            string procName = "Company.DepartmentInsert";

            var res = _db.SaveData<DepartmentModel, int>(procName, department);

            return res;
        }

        ///// <summary>
        ///// Get department object by Id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public Task<DepartmentModel> GetDepartmentById(int id)
        //{
        //    string procName = "Company.DepartmentSelectById";

        //    return _db.LoadDataById<DepartmentModel, dynamic>(procName, new { DepartmentId = id });
        //}

        /// <summary>
        /// Get all the departments from db based on department object params
        /// </summary>
        /// <param name="plant">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns></returns>
        public Task<List<DepartmentModel>> GetDepartmentList(DepartmentModel department)
        {
            string procName = "Company.DepartmentSelect";

            if (department.DepartmentId ==0)
            {
                return _db.LoadData<DepartmentModel, dynamic>(procName, new
                {
                    DepartmentId="%",
                    department.Name
                });
            }
            else
            {
                return _db.LoadData<DepartmentModel, dynamic>(procName, new
                {
                    department.DepartmentId,
                    department.Name
                });
            }

           


        }
    }
}
