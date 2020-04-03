using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactorySystems.CommonLibrary.PersistanceModels
{
    /// <summary>
    /// Types of params from SQL:
    /// MachineId int IDENTITY,
    /// CostCenterId int NOT NULL,
    /// MachineCategoryId int NOT NULL,
    /// MachineStatusId int NOT NULL,
    /// Name nvarchar(200) NOT NULL,
    /// Description nvarchar(4000) NULL,
    /// RatePerHour money NULL,
    /// SetupTime numeric(18, 3) NULL,
    /// ProcessTime numeric(18, 3) NULL,
    /// PartsPerCycle numeric(18, 1) NULL,
    /// AlarmOnOff bit NULL,
    /// AlarmDate datetime2 NULL,
    /// ActivityDate datetime2 NULL,
    /// LastActivityDate datetime2 NULL,
    /// ModifiedDate datetime2 NULL,
    /// </summary>

    public class MachineModel
    {
        public MachineModel()
        {
            MachineId = 0;
            CostCenterId = 0;
            MachineCategoryId = 0;
            MachineStatusId = 0;
            Name = "%";
            Description = "%";
            RatePerHour = 0;
            SetupTime = 0;
            ProcessTime = 0;
            PartsPerCycle = 0;
            AlarmOnOff = -1;
            AlarmDate = DateTime.Now;
            ActivityDate = DateTime.Now;
            LastActivityDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
        /// <summary>
        /// Annotation for getting the property name in DAL
        /// Primary key in SQL
        /// </summary>      
        [Key]
        public int MachineId { get; set; }
        /// <summary>
        /// Id of the Costcenter in Machine table
        /// Foreign key
        /// </summary>
        public int CostCenterId { get; set; }
        /// <summary>
        /// Id of the Machine category in Machine table
        /// Foreign key
        /// </summary>
        public int MachineCategoryId { get; set; }
        /// <summary>
        /// Id of the machine status in Machine table
        /// Foreign key
        /// </summary>
        public int MachineStatusId { get; set; }
        /// <summary>
        /// Name of the machine
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description of the machine
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Hour rate of the machine
        /// </summary>
        public decimal RatePerHour { get; set; }
        /// <summary>
        /// Setup time of the machine
        /// </summary>
        public double SetupTime { get; set; }
        /// <summary>
        /// Process time of the machine
        /// </summary>
        public double ProcessTime { get; set; }
        /// <summary>
        /// Simultaneous parts produced of the machine
        /// </summary>
        public double PartsPerCycle { get; set; }
        /// <summary>
        /// Alarm state
        /// </summary>
        public int AlarmOnOff { get; set; }
        /// <summary>
        /// Alarm date
        /// </summary>
        public DateTime AlarmDate { get; set; }
        /// <summary>
        /// Activity date
        /// </summary>
        public DateTime ActivityDate { get; set; }
        /// <summary>
        /// Last activity date
        /// </summary>
        public DateTime LastActivityDate { get; set; }
        /// <summary>
        /// Last modified date of the properties
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }

}
