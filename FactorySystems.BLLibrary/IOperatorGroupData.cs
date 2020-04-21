using FactorySystems.CommonLibrary.PersistanceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary
{
    public interface IOperatorGroupData
    {
        Task DeleteOperatorGroup(int groupId);
        Task<List<OperatorGroupModel>> GetOperatorGroupList(OperatorGroupModel group);
        Task<int> InsertOperatorGroup(OperatorGroupModel group);
        Task UpdateOperatorGroup(OperatorGroupModel group);
    }
}