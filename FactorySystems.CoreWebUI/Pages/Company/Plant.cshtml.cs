using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactorySystems.BLLibrary.CompanyData;
using FactorySystems.DALibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactorySystems.CoreWebUI.Pages.Company
{
    public class PlantModel : PageModel
    {

        private readonly IPlantData plantData;

        //InitializeConnection(DatabaseAccesType.Dapper);

        public List<CommonLibrary.PersistanceModels.PlantModel> Plants { get; set; }

        public PlantModel(IPlantData plantData)
        {
            this.plantData = plantData;
        }

        public async void OnGet()
        {
            Plants = await plantData.GetPlantList(new CommonLibrary.PersistanceModels.PlantModel());
        }
    }
}