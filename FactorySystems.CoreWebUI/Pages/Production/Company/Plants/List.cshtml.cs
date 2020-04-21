using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactorySystems.BLLibrary;
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
        private readonly IPlantData _plantData;

        [TempData]
        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List<PlantVM> Plants { get; set; } = new List<PlantVM>();
        public PlantVM PlantVM { get; set; } = new PlantVM();

        public ListModel(IPlantData plantData)
        {
            _plantData = plantData;
        }

        public void OnGet()
        {
            if (SearchTerm == null)
            {
                Plants = _plantData.GetPlants().GetAwaiter().GetResult();

            }
            else
            {
                PlantVM.Name = SearchTerm;
                Plants = _plantData.GetPlants(PlantVM).GetAwaiter().GetResult();
            }

            //DbPlants = plantData.GetPlantList(ConvertVMToPersistance(PlantVM)).GetAwaiter().GetResult();
            //Plants = ConvertPersistanceToVM(DbPlants);
            
        }
    }
}