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

namespace FactorySystems.CoreWebUI.Pages.Production.Company.Departments
{
    public class ListModel : PageModel
    {
        private readonly IDepartmentData _departmentData;
        private readonly IPlantData _plantData;

        public List<DepartmentVM> Departments { get; set; } = new List<DepartmentVM>();
        public List<PlantVM> Plants { get; set; } = new List<PlantVM>();
        public DepartmentVM Department { get; set; } = new DepartmentVM();
        public PlantVM Plant { get; set; } = new PlantVM();


        [TempData]
        public string Message { get; set; }


        public ListModel(IDepartmentData departmentData, IPlantData plantData)
        {
            _departmentData = departmentData;
            _plantData = plantData;
        }
        public void OnGet()
        {
            Departments=_departmentData.GetDepartments().GetAwaiter().GetResult();
            Plants = _plantData.GetPlants().GetAwaiter().GetResult();

            //foreach (var plant in Plants)
            //{
            //    plant.Departments=
            //}
            //PlantVM{ PlantId = plant.PlantId,Address = plant.Address,City = plant.City, Email = plant.Email,Name = plant.Name,Phone = plant.Phone,Departments = Departments };
            var query = from plant in Plants
                        join department in Departments on plant.PlantId equals department.PlantId
                        select new DepartmentVM { DepartmentId = department.DepartmentId, PlantId = plant.PlantId, Plant = plant, Name = department.Name, Description = department.Description };

            var asd = query.ToList();
            
        }

    }
}