using FactorySystems.BLLibrary;
using FactorySystems.DALibrary;
using static FactorySystems.DALibrary.GlobalConfig;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using FactorySystems.CommonLibrary.Models;
using System.Threading.Tasks;
using FactorySystems.BLLibrary.CompanyData;

namespace FactorySystems.ConsoleUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            InitializeConnection(DatabaseAccesType.Dapper);

            PlantData plant = new PlantData(Connection);


            DepartmentData department = new DepartmentData(Connection);


            var pl = await plant.GetPlantList(new PlantModel() { PlantId=3});


            PlantModel plantModel = new PlantModel
            {
                PlantId= pl[0].PlantId,
                Name = pl[0].Name,
                Address = pl[0].Address,
                City = pl[0].City,
                Phone = pl[0].Phone,
                Email = pl[0].Email
            };

            DepartmentModel departmentModel = new DepartmentModel
            {
                PlantId = plantModel.PlantId,
                Name = "Asamblare2",
                Description = "Departamentul de asamblare2",
            };
            
            int dep = await department.InsertDepartment(departmentModel);


            //int x = await plant.InsertPlant(plantModel);

            //plantModel.PlantId = x;

            dp = await department.GetDepartmentList(new DepartmentModel() { PlantId = 3 });


            departmentModel.DepartmentId = dep;

            departmentModel.Name = "Asamblare2";
            departmentModel.PlantId = 1006;
            departmentModel.Description = "Alt departament";
            await department.UpdateDepartment(departmentModel);

            await department.DeleteDepartment(12);

            DepartmentModel model = new DepartmentModel();


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
