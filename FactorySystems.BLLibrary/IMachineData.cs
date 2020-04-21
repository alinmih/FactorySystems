using FactorySystems.CommonLibrary.PersistanceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary
{
    public interface IMachineData
    {
        Task DeleteMachine(int machineId);
        Task<List<MachineModel>> GetMachineList(MachineModel machine);
        Task<int> InsertMachine(MachineModel machine);
        Task UpdateMachine(MachineModel machine);
    }
}