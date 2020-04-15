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
    public class EditModel : PageModel
    {
        private readonly IPlantData plantData;
        private readonly IAdapter adapter;

        [BindProperty]
        public PlantVM Plant{ get; set; }
        [TempData]
        public string Message { get; set; }


        private PlantModel PlandDbModel { get; set; } = new PlantModel();


        public EditModel(IPlantData plantData, IAdapter adapter)
        {
            this.plantData = plantData;
            this.adapter = adapter;
        }
        public async Task<IActionResult> OnGet(int? plantId)
        {
            if (plantId.HasValue)
            {
                PlandDbModel.PlantId = plantId.Value;
                var plant = await plantData.GetPlantList(PlandDbModel);
                Plant = adapter.Convert<PlantVM, PlantModel>(plant.FirstOrDefault());
            }
            else
            {
                Plant = new PlantVM();
            }

            if (Plant==null)
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
            if (Plant.PlantId >0)
            {
                PlandDbModel = adapter.Convert<PlantModel, PlantVM>(Plant);
                await plantData.UpdatePlant(PlandDbModel);
            }
            else
            {
                PlandDbModel = adapter.Convert<PlantModel, PlantVM>(Plant);
                var id = await plantData.InsertPlant(PlandDbModel);
            }

            TempData["Message"] = $"{Plant.Name} has been saved.";
            return RedirectToPage("./List");
        }
    }
}