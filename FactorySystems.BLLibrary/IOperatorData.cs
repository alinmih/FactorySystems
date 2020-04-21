using FactorySystems.CommonLibrary.PersistanceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary
{
    public interface IOperatorData
    {
        Task DeleteOperator(int operatorId);
        Task<List<OperatorModel>> GetOperatorList(OperatorModel operatorModel);
        Task<int> InsertOperator(OperatorModel operatorModel);
        Task UpdateOperator(OperatorModel operatorModel);
    }
}