using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactorySystems.CommonLibrary.PersistanceModels
{
    /// <summary>
    /// Types of params from SQL:
    /// MachineStatusId int IDENTITY,
    /// Status nvarchar(50) NOT NULL,
    /// </summary>
    public class MachineStatusModel
    {
        public MachineStatusModel()
        {
            MachineStatusId = 0;
            Status = "%";
        }

        /// <summary>
        /// Annotation for getting the property name in DAL
        /// Primary key in SQL
        /// </summary>     
        [Key]
        public int MachineStatusId { get; set; }

        /// <summary>
        /// Name of the machine status
        /// </summary>
        public string Status { get; set; }
    }
}
