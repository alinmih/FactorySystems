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
    public class DeleteModel : PageModel
    {
        private readonly IPlantData _plantData;

        public PlantVM Plant { get; set; } = new PlantVM();

        public DeleteModel(IPlantData plantData)
        {
            _plantData = plantData;
        }
        public async Task<IActionResult> OnGet(int plantId)
        {
            Plant.PlantId = plantId;
            var plant = await _plantData.GetPlants(Plant);
            Plant = plant.FirstOrDefault();

            if (Plant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int plantId)
        {
            await _plantData.DeletePlant(plantId);

            TempData["Message"] = $"Plant deleted";
            return RedirectToPage("./List");
        }
    }
}