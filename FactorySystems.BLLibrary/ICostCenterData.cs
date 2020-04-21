using FactorySystems.CommonLibrary.PersistanceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary
{
    public interface ICostCenterData
    {
        Task DeleteCostCenter(int costCenterId);
        Task<List<CostCenterModel>> GetCostCenterList(CostCenterModel costCenter);
        Task<int> InsertCostCenter(CostCenterModel costCenter);
        Task UpdateCostCenter(CostCenterModel costCenter);
    }
}