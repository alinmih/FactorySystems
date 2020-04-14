using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactorySystems.CoreWebUI.ViewComponents
{
    enum Production
    {
        Company,
        Products,
        Production,
        Sales
    }
    public class ProductionMenuViewComponent : ViewComponent
    {
        public ProductionMenuViewComponent()
        {

        }

        public IViewComponentResult Invoke()
        {
            var productionComponents = Enum.GetNames(typeof(Production)).ToList();

            return View(productionComponents);
        }
    }
}
