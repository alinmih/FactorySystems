using FactorySystems.DALibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.CommonLibrary.Adapters;
using FactorySystems.CommonLibrary.ViewModels;
using System.Linq;

namespace FactorySystems.BLLibrary.CompanyData
{
    public class DepartmentData : IDepartmentData
    {
        /// <summary>
        /// Reference to Sql data access layer
        /// </summary>
        private readonly IDataAccess _db;
        private readonly IAdapter _adapter;
        private readonly IPlantData _plantData;

        public DepartmentData(IDataAccess db, IAdapter adapter, IPlantData plantData)
        {
            _db = db;
            _adapter = adapter;
            _plantData = plantData;
        }

        /// <summary>
        /// Insert into DB a department object
        /// </summary>
        /// <param name="department">PersistenceModel send as param with default or specific props</param>
        /// <returns></returns>
        internal Task<int> InsertDepartment(DepartmentModel department)
        {
            string procName = "Company.DepartmentInsert";

            var res = _db.SaveDataAsync<DepartmentModel, int>(procName, department);

            return res;
        }

        /// <summary>
        /// Insert into DB a department object
        /// </summary>
        /// <param name="department">Deparment view model send as param with default or specific props</param>
        /// <returns></returns>
        public Task<int> InsertDepartment(DepartmentVM department)
        {
            return InsertDepartment(_adapter.ConvertToTFromU<DepartmentModel, DepartmentVM>(department));
        }

        /// <summary>
        /// Get all the departments from db based on department object params
        /// </summary>
        /// <param name="plant">Model to search for. Params must be initialized with '%' for search</param>
        /// <returns></returns>
        internal Task<List<DepartmentModel>> GetDepartmentList(DepartmentModel department)
        {
            string procName = "Company.DepartmentSelect";

            return _db.GetDataAsync<DepartmentModel, dynamic>(procName, department);
        }

        /// <summary>
        /// Get all the departments from db based on department object params
        /// </summary>
        /// <returns></returns>
        internal Task<List<DepartmentModel>> GetDepartmentList()
        {
            DepartmentModel department = new DepartmentModel();
            string procName = "Company.DepartmentSelect";

            return _db.GetDataAsync<DepartmentModel, dynamic>(procName, department);
        }

        /// <summary>
        /// Get all the departments from db
        /// </summary>
        /// <returns></returns>
        public async Task<List<DepartmentVM>> GetDepartments()
        {
            //PlantData plantData = new PlantData(_db, _adapter);
            List<DepartmentVM> departments = _adapter
                .ConvertToTListFromU<DepartmentVM, DepartmentModel>(await GetDepartmentList());
            PlantVM plant = new PlantVM();
            foreach (var item in departments)
            {
                plant.PlantId = item.PlantId;
                item.Plant = _plantData.GetPlants(plant).GetAwaiter().GetResult().FirstOrDefault();
            }

            return departments;
        }

        /// <summary>
        /// Get all the departments from db based on department object params
        /// <param name="department">Model to search for.</param>
        /// </summary>
        /// <returns></returns>
        public async Task<List<DepartmentVM>> GetDepartments(DepartmentVM department)
        {
            List<DepartmentVM> departments = _adapter
                .ConvertToTListFromU<DepartmentVM, DepartmentModel>(
                await GetDepartmentList(_adapter.ConvertToTFromU<DepartmentModel, DepartmentVM>(department)));
            PlantVM plant = new PlantVM();
            foreach (var item in departments)
            {
                plant.PlantId = item.PlantId;
                item.Plant = _plantData.GetPlants(plant).GetAwaiter().GetResult().FirstOrDefault();
            }

            return departments;
        }


        /// <summary>
        /// Update specific department from db
        /// </summary>
        /// <param name="department">Model to update</param>
        /// <returns></returns>
        internal Task UpdateDepartment(DepartmentModel department)
        {
            string procName = "Company.DepartmentUpdate";

            return _db.UpdateDataAsync(procName, department);
        }

        /// <summary>
        /// Update specific department from db
        /// </summary>
        /// <param name="department">Model to update</param>
        /// <returns></returns>
        public Task UpdateDepartment(DepartmentVM department)
        {
            return UpdateDepartment(_adapter.ConvertToTFromU<DepartmentModel, DepartmentVM>(department));
        }

        /// <summary>
        /// Delete a department by id
        /// </summary>
        /// <param name="plantId">Id of the department</param>
        /// <returns></returns>
        public Task DeleteDepartment(int departmentId)
        {
            string procName = "Company.DepartmentDelete";

            return _db.DeleteDataAsync(procName, new { DepartmentId = departmentId });

        }
    }
}
