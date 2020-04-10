using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.CommonLibrary.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary.CompanyData
{
    public interface IPlantData
    {
        Task DeletePlant(int plantId);
        Task<List<PlantModel>> GetPlantList(PlantModel plant);
        Task<int> InsertPlant(PlantModel plant);
        Task UpdatePlant(PlantModel plant);
    }
}