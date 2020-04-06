using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactorySystems.CommonLibrary.PersistanceModels
{
    /// <summary>
    /// Types of params from SQL:
    /// OperatorId int IDENTITY,
    /// DutyId int NOT NULL,
    /// OperatorGroupId int NOT NULL,
    /// DepartmentId int NOT NULL,
    /// BadgeNumber nvarchar(200) NOT NULL,
    /// FirstName nvarchar(200) NOT NULL,
    /// LastName nvarchar(200) NOT NULL,
    /// LastActionTime datetime2 NULL,
    /// </summary>
    public class OperatorModel
    {
        public OperatorModel()
        {
            OperatorId = 0;
            DutyId = 0;
            OperatorGroupId = 0;
            DepartmentId = 0;
            BadgeNumber = "%";
            FirstName = "%";
            LastName = "%";
            LastActionTime = DateTime.Now;
        }

        /// <summary>
        /// Annotation for getting the property name in DAL
        /// Primary key in SQL
        /// </summary>     
        [Key]
        public int OperatorId { get; set; }
        /// <summary>
        /// Id of the Duty in OperatorDuty table
        /// Foreign key
        /// </summary>
        public int DutyId { get; set; }
        /// <summary>
        /// Id of the Group in OperatorGroup table
        /// Foreign key
        /// </summary>
        public int OperatorGroupId { get; set; }
        /// <summary>
        /// Id of the Department in Department table
        /// Foreign key
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Badge number of the operator
        /// </summary>
        public string BadgeNumber { get; set; }
        /// <summary>
        /// First name of the operator
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the operator
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Last action time performed by the operator
        /// </summary>
        public DateTime LastActionTime { get; set; }

    }
}
