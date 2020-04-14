using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactorySystems.CoreWebUI.ViewComponents
{
    enum Pages
    {
        Production,
        Traceability,
        Quality,
        Warehouse,
        KPI
    }
    public class MainMenuViewComponent : ViewComponent
    {
        public MainMenuViewComponent()
        {

        }

        public IViewComponentResult Invoke()
        {
            var pagesComponents = Enum.GetNames(typeof(Pages)).ToList();

            return View(pagesComponents);
        }
    }
}
