using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.CommonLibrary.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.BLLibrary
{
    public interface IPlantData
    {
        Task<List<PlantVM>> GetPlants();
        Task<List<PlantVM>> GetPlants(PlantVM plant);
        Task<int> InsertPlant(PlantVM plant);
        Task UpdatePlant(PlantVM plant);
        Task DeletePlant(int plantId);
    }
}