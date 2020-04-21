using FactorySystems.DALibrary;
using static FactorySystems.DALibrary.GlobalConfig;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using FactorySystems.CommonLibrary.PersistanceModels;
using System.Threading.Tasks;
using FactorySystems.BLLibrary.CompanyData;
using FactorySystems.CommonLibrary.ViewModels;

namespace FactorySystems.ConsoleUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            InitializeConnection(DatabaseAccesType.Dapper);

            var Connection = GlobalConfig.Connection;
            FactorySystems.CommonLibrary.Adapters.IAdapter adapter = new FactorySystems.CommonLibrary.Adapters.Adapter();

            PlantData plant = new PlantData(Connection,adapter);

            var plants = plant.GetPlants(new PlantVM());

            DepartmentData department = new DepartmentData(Connection);

            var d= await department.GetDepartmentList(new DepartmentModel());

            CostCenterData costcenter = new CostCenterData(Connection);

            MachineCategoryData machineCategory = new MachineCategoryData(Connection);

            MachineStatusData machineStatus = new MachineStatusData(Connection);

            MachineData machine = new MachineData(Connection);

            OperatorDutyData operatorDuty = new OperatorDutyData(Connection);

            OperatorGroupData operatorGroup = new OperatorGroupData(Connection);

            OperatorData operatorData = new OperatorData(Connection);

 
        }


    }
}
