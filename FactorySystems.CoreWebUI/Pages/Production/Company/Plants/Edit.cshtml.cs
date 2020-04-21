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
    public class EditModel : PageModel
    {
        private readonly IPlantData _plantData;

        [BindProperty]
        public PlantVM Plant { get; set; } = new PlantVM();
        [TempData]
        public string Message { get; set; }

        public EditModel(IPlantData plantData)
        {
            _plantData = plantData;
        }
        public async Task<IActionResult> OnGet(int? plantId)
        {
            if (plantId.HasValue)
            {
                Plant.PlantId = plantId.Value;
                var plant = await _plantData.GetPlants(Plant);
                Plant = plant.FirstOrDefault();
            }
            else
            {
                Plant = new PlantVM();
            }

            if (Plant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Plant.PlantId > 0)
            {
                await _plantData.UpdatePlant(Plant);
            }
            else
            {
                var id = await _plantData.InsertPlant(Plant);
            }

            TempData["Message"] = $"{Plant.Name} has been saved.";
            return RedirectToPage("./List");
        }
    }
}