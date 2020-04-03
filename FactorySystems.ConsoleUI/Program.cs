using FactorySystems.DALibrary;
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

            MachineData machine = new MachineData(Connection);

            OperatorDutyData operatorDuty = new OperatorDutyData(Connection);

            OperatorGroupData operatorGroup = new OperatorGroupData(Connection);



        }


    }
}
