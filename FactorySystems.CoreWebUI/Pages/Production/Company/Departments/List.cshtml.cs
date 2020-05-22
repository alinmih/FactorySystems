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

        public List<DepartmentVM> Departments { get; set; } = new List<DepartmentVM>();
        public List<PlantVM> Plants { get; set; } = new List<PlantVM>();
        public DepartmentVM Department { get; set; } = new DepartmentVM();
        public PlantVM Plant { get; set; } = new PlantVM();


        [TempData]
        public string Message { get; set; }


        public ListModel(IDepartmentData departmentData)
        {
            _departmentData = departmentData;
        }
        public void OnGet()
        {
            
            Departments =_departmentData.GetDepartments(Department).GetAwaiter().GetResult();
           
        }

    }
}