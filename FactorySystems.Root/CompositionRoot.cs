﻿using FactorySystems.BLLibrary.CompanyData;
using FactorySystems.CommonLibrary.Adapters;
using FactorySystems.DALibrary;
using Microsoft.AspNetCore.Http;
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
            services.AddScoped<IAdapter, Adapter>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
