using FactorySystems.BLLibrary.CompanyData;
using FactorySystems.DALibrary;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorySystems.Root
{
    public class CompositionRoot
    {
        public CompositionRoot()
        {
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<ISqlDataAccess, SqlDataAccess>();
            services.AddScoped<IPlantData, PlantData>();
        }
    }
}
