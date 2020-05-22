using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactorySystems.BLLibrary;
using FactorySystems.CommonLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FactorySystems.CoreWebUI.Pages.Production.Company.Departments
{
    public class EditModel : PageModel
    {
        private readonly IPlantData _plantData;
        private readonly IDepartmentData _departmentData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public DepartmentVM Department { get; set; } = new DepartmentVM();

        public IEnumerable<SelectListItem> PlantsList { get; set; }

        [TempData]
        public string Message { get; set; }

        public EditModel(IPlantData plantData, IDepartmentData departmentData, IHtmlHelper htmlHelper)
        {
            _plantData = plantData;
            _departmentData = departmentData;
            _htmlHelper = htmlHelper;
        }

        public async Task<IActionResult> OnGet(int? departmentId)
        {
            PlantsList = _plantData.GetPlants()
                .GetAwaiter().GetResult().Select(a => new SelectListItem
                {
                    Value = a.PlantId.ToString(),
                    Text = a.Name
                });

            if (departmentId.HasValue)
            {
                Department.DepartmentId = departmentId.Value;
                var dep = await _departmentData.GetDepartments(Department);
                Department = dep.FirstOrDefault();
            }
            else
            {
                Department = new DepartmentVM();
            }
            if (Department == null)
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
            if (Department.DepartmentId > 0)
            {
                await _departmentData.UpdateDepartment(Department);
            }
            else
            {
                var id = await _departmentData.InsertDepartment(Department);
                Department.DepartmentId = id;
            }

            TempData["Message"] = $"{Department.Name} has been saved.";
            return RedirectToPage("./List");
        }
    }
}