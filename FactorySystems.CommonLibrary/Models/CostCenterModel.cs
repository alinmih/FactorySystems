using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactorySystems.CommonLibrary.Models
{
    /// <summary>
    /// Types of params from SQL:
    ///   CostCenterId int IDENTITY,
    ///   DepartmentId int NOT NULL,
    ///   Name nvarchar(200) NOT NULL,
    ///   Description nvarchar(4000) NULL,
    ///   Cost money NULL,
    ///   AverageCost money NULL,
    ///   ModifiedDate datetime2 NULL,
    /// </summary>
    public class CostCenterModel
    {
        public CostCenterModel()
        {
            CostCenterId = 0;
            DepartmentId = 0;
            Name = "%";
            Description = "%";
            Cost = 0;
            AverageCost = 0;
            ModifiedDate = DateTime.Now;
        }
        /// <summary>
        /// Annotation for getting the property name in DAL
        /// Primary key in SQL
        /// </summary>      
        [Key]
        public int CostCenterId { get; set; }

        /// <summary>
        /// Id of the department in department table
        /// Foreign key
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Name of the cost center
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the cost center
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Current cost of the cost center
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Average cost of the cost center
        /// </summary>
        public decimal AverageCost { get; set; }

        /// <summary>
        /// Last modified date
        /// </summary>
        public DateTime ModifiedDate { get; set; }

    }
}
