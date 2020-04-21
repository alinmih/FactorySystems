using FactorySystems.CommonLibrary.PersistanceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary
{
    public interface IMachineStatusData
    {
        Task DeleteMachineStatus(int machineStatusId);
        Task<List<MachineStatusModel>> GetMachineStatusList(MachineStatusModel machineStatus);
        Task<int> InsertMachineStatus(MachineStatusModel machineStatus);
        Task UpdateMachineStatus(MachineStatusModel machineStatus);
    }
}