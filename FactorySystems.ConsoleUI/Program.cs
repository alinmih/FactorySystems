﻿using FactorySystems.DALibrary;
using static FactorySystems.DALibrary.GlobalConfig;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using FactorySystems.CommonLibrary.PersistanceModels;
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

            CostCenterData costcenter = new CostCenterData(Connection);

            MachineCategoryData machineCategory = new MachineCategoryData(Connection);

            MachineStatusData machineStatus = new MachineStatusData(Connection);


            var pl = await plant.GetPlantList(new PlantModel() { PlantId = 3 });

            MachineStatusModel statusModel = new MachineStatusModel
            {
                Status = "Stopped"
            };
            var st = await machineStatus.InsertMachineStatus(statusModel);
            var st2 = await machineStatus.GetMachineStatusList(new MachineStatusModel());
            var st3 = await machineStatus.GetMachineStatusList(new MachineStatusModel() { Status = "Stopped" });

            MachineStatusModel statusModel2 = new MachineStatusModel
            {
                MachineStatusId = st,
                Status = "Running"
            };

            await machineStatus.UpdateMachineStatus(statusModel2);
            await machineStatus.DeleteMachineStatus(st);





            MachineCategoryModel categoryModel = new MachineCategoryModel
            {
                Category = "Finite"
            };

            var id = await machineCategory.InsertMachineCategory(categoryModel);
            var cat = await machineCategory.GetMachineCategoryList(new MachineCategoryModel());
            var cat2 = await machineCategory.GetMachineCategoryList(new MachineCategoryModel() { Category = "Finite" });
            MachineCategoryModel categoryModel2 = new MachineCategoryModel
            {
                MachineCategoryId = id,
                Category = "Infinite"
            };
            await machineCategory.UpdateMachineCategory(categoryModel2);
            await machineCategory.DeleteMachineCategory(cat2[0].MachineCategoryId);



            PlantModel plantModel = new PlantModel
            {
                PlantId = pl[0].PlantId,
                Name = pl[0].Name,
                Address = pl[0].Address,
                City = pl[0].City,
                Phone = pl[0].Phone,
                Email = pl[0].Email
            };

            DepartmentModel departmentModel = new DepartmentModel
            {
                PlantId = plantModel.PlantId,
                Name = "Asamblare3",
                //Description = "Departamentul de asamblare2",
            };

            var dp = await department.GetDepartmentList(departmentModel);

            CostCenterModel costCenterModel = new CostCenterModel
            {
                CostCenterId = 5,
                DepartmentId = dp[0].DepartmentId,
                Name = "Cost center33333",
                Description = "Primul cost center22333332",
                Cost = 222.99M,
                AverageCost = 124.99M,
                ModifiedDate = DateTime.Now
            };

            //int cc = await costcenter.InsertCostCenter(costCenterModel);
            //await costcenter.DeleteCostCenter(1);
            await costcenter.UpdateCostCenter(costCenterModel);
            var ccc = await costcenter.GetCostCenterList(new CostCenterModel() { });

            //int dep = await department.InsertDepartment(departmentModel);


            //int x = await plant.InsertPlant(plantModel);

            //plantModel.PlantId = x;

            dp = await department.GetDepartmentList(new DepartmentModel() { PlantId = 3 });


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
