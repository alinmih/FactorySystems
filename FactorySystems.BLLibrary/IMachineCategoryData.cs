using FactorySystems.CommonLibrary.PersistanceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary
{
    public interface IMachineCategoryData
    {
        Task DeleteMachineCategory(int machineCategoryId);
        Task<List<MachineCategoryModel>> GetMachineCategoryList(MachineCategoryModel machineCategory);
        Task<int> InsertMachineCategory(MachineCategoryModel machineCategory);
        Task UpdateMachineCategory(MachineCategoryModel machineCategory);
    }
}