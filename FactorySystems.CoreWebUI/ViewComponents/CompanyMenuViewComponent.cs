using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactorySystems.CoreWebUI.ViewComponents
{
    public enum Company
    {
        Plants,
        Departments,
        CostCenters,
        Machines,
        Operators
    }

    public class CompanyMenuViewComponent : ViewComponent
    {
        public CompanyMenuViewComponent()
        {

        }

        public IViewComponentResult Invoke()
        {
            var companyComponents = Enum.GetNames(typeof(Company)).ToList();

            return View(companyComponents);
        }
    }
}
