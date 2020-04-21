using FactorySystems.CommonLibrary.PersistanceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary
{
    public interface IOperatorDutyData
    {
        Task DeleteOperatorDuty(int dutyId);
        Task<List<OperatorDutyModel>> GetOperatorDutyList(OperatorDutyModel duty);
        Task<int> InsertOperatorDuty(OperatorDutyModel duty);
        Task UpdateOperatorDuty(OperatorDutyModel duty);
    }
}