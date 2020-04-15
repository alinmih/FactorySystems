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
    public class DeleteModel : PageModel
    {
        private readonly IPlantData plantData;
        private readonly IAdapter adapter;

        public PlantVM Plant { get; set; }
        private PlantModel PlandDbModel { get; set; } = new PlantModel();

        public DeleteModel(IPlantData plantData, IAdapter adapter)
        {
            this.plantData = plantData;
            this.adapter = adapter;
        }
        public IActionResult OnGet(int plantId)
        {
            PlandDbModel.PlantId = plantId;
            var plant = plantData.GetPlantList(PlandDbModel).GetAwaiter().GetResult();
            Plant = adapter.Convert<PlantVM, PlantModel>(plant.FirstOrDefault());

            if (Plant==null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int plantId)
        {
            plantData.DeletePlant(plantId).GetAwaiter().GetResult();

            TempData["Message"] = $"Plant deleted";
            return RedirectToPage("./List");
        }
    }
}