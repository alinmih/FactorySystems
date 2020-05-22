using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactorySystems.BLLibrary;
using FactorySystems.CommonLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactorySystems.CoreWebUI.Pages.Production.Company.Departments
{
    public class DeleteModel : PageModel
    {
        private readonly IDepartmentData _departmentData;

        [BindProperty]
        public DepartmentVM Department { get; set; } = new DepartmentVM();

        public DeleteModel(IDepartmentData departmentData)
        {
            _departmentData = departmentData;
        }
        public async Task<IActionResult> OnGet(int departmentId)
        {
            Department.DepartmentId = departmentId;
            var dep = await _departmentData.GetDepartments(Department);
            Department = dep.FirstOrDefault();

            if (Department==null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int departmentId)
        {
            await _departmentData.DeleteDepartment(departmentId);

            TempData["Message"] = $"Department deleted";
            return RedirectToPage("./List");
        }
    }
}