using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactorySystems.CommonLibrary.PersistanceModels
{
    /// <summary>
    /// Types of params from SQL:
    /// DutyId int IDENTITY,
    /// DutyName nvarchar(200) NOT NULL,
    /// </summary>
    public class OperatorDutyModel
    {
        public OperatorDutyModel()
        {
            DutyId = 0;
            DutyName = "%";
        }
        /// <summary>
        /// Annotation for getting the property name in DAL
        /// Primary key in SQL
        /// </summary>      
        [Key]
        public int DutyId { get; set; }

        /// <summary>
        /// Name of the duty category
        /// </summary>
        public string DutyName { get; set; }
    }
}
