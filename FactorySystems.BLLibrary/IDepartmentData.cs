using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.CommonLibrary.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary
{
    public interface IDepartmentData
    {
        Task<List<DepartmentVM>> GetDepartments();
        Task<List<DepartmentVM>> GetDepartments(DepartmentVM department);
        Task<int> InsertDepartment(DepartmentVM department);
        Task UpdateDepartment(DepartmentVM department);
        Task DeleteDepartment(int departmentId);
    }
}