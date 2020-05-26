using FactorySystems.BLLibrary;
using FactorySystems.CommonLibrary.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.ConsoleUI
{
    public class App
    {
        private readonly IConfigurationRoot _config;
        private readonly IPlantData _plantData;
        private readonly ILogger<App> _loggerFactory;

        public App(ILoggerFactory loggerFactory, IPlantData plantData)
        {
            _plantData = plantData;
            _loggerFactory = loggerFactory.CreateLogger<App>();
        }
        public async Task Run()
        {
            //List<string> emailAddresses = _config.GetSection("EmailAddresses").Get<List<string>>();
            //foreach (string emailAddress in emailAddresses)
            //{
            //    _loggerFactory.LogInformation("Email address: {@EmailAddress}", emailAddress);
            //}
            var plantVM = new PlantVM();
            //plantVM.Name = "Bla bla";

            try
            {
                var id = await _plantData.InsertPlant(plantVM);
            }
            catch (System.Exception ex)
            {
                _loggerFactory.LogWarning("{Message}", ex.Message);
            }

            var result = await _plantData.GetPlants(plantVM);

            foreach (var item in result)
            {
                _loggerFactory.LogInformation("{1}-{2}-{3}-{4}-{5}-{6}",item.PlantId,item.Name,item.Address,item.City,item.Email,item.Phone);
            }

        }
    }
}