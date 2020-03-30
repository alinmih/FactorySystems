using FactorySystems.BLLibrary;
using FactorySystems.DALibrary;
using static FactorySystems.DALibrary.GlobalConfig;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using FactorySystems.CommonLibrary.Models;
using System.Threading.Tasks;

namespace FactorySystems.ConsoleUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            InitializeConnection(DatabaseAccesType.Dapper);

            PlantData plant = new PlantData(Connection);

            DepartmentData department = new DepartmentData(Connection);
            PlantModel plantModel = new PlantModel
            {
                Name = "Prima fabrica",
                Address = "Traian 4",
                City = "Brasov",
                Phone = "0722304315",
                Email = "alin@alin.com"
            };

            int x = await plant.InsertPlant(plantModel);
            Console.WriteLine(x);

            plantModel.PlantId = x;

            DepartmentModel departmentModel = new DepartmentModel
            {
                PlantId = plantModel.PlantId,
                Name = "Asamblare",
                Description = "Departamentul de asamblare",
            };

            int dep = await department.InsertDepartment(departmentModel);

            departmentModel.DepartmentId = dep;

            DepartmentModel model = new DepartmentModel
            {
                DepartmentId = 0,
                Name = "%",
            };

            var dep2 = await department.GetDepartmentList(model);

            

            PlantModel plantModel3 = new PlantModel
            {
                Name = "AAA",
                Address = "%",
                City = "%",
                Phone = "%",
                Email = "%"
            };

            //await plant.UpdatePlant(plantModel2);
            //await plant.DeletePlant(45);

            //var z = await plant.GetPlantById(plantModel2.PlantId);
            //var zz = await plant.GetPlantList(plantModel3);

            await plant.DeletePlant(2);
            //Console.WriteLine(z.PlantId);
            //Console.WriteLine(z.Name);
            //Console.WriteLine(z.Address);
            //Console.WriteLine(z.City);
            //Console.WriteLine(z.Phone);
            //Console.WriteLine(z.Email);

            //await plant.GetPlants();

            
        
        }


    }
}
