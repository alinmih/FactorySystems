using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactorySystems.BLLibrary.CompanyData;
using FactorySystems.CommonLibrary.Adapters;
using FactorySystems.CommonLibrary.PersistanceModels;
using FactorySystems.CommonLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactorySystems.CoreWebUI.Pages.Production.Company.Plants
{
    public class ListModel : PageModel
    {
        private readonly IPlantData plantData;
        private readonly IAdapter adapter;

        private List<PlantModel> DbPlants= new List<PlantModel>();
        private PlantModel PlantModel = new PlantModel();

        public List<PlantVM> Plants { get; set; } = new List<PlantVM>();
        public PlantVM PlantVM { get; set; } = new PlantVM();



        public ListModel(IPlantData plantData, IAdapter adapter)
        {
            this.plantData = plantData;
            this.adapter = adapter;
        }

        public void OnGet()
        {
            DbPlants = plantData.GetPlantList(ConvertVMToPersistance(PlantVM)).GetAwaiter().GetResult();
            Plants = ConvertPersistanceToVM(DbPlants);
        }

        private PlantModel ConvertVMToPersistance(PlantVM plantVM)
        {
            return adapter.Convert<PlantModel, PlantVM>(plantVM);
        }

        private List<PlantVM> ConvertPersistanceToVM(List<PlantModel> dbPlants)
        {
            return adapter.ConvertToList<PlantVM, PlantModel>(dbPlants);
        }
    }
}