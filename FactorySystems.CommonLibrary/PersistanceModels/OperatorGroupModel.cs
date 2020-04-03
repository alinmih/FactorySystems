using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactorySystems.CommonLibrary.PersistanceModels
{
    /// <summary>
    /// Types of params from SQL:
    /// OperatorGroupId int IDENTITY,
    /// GroupName nvarchar(200) NOT NULL,
    /// </summary>
    public class OperatorGroupModel
    {
        public OperatorGroupModel()
        {
            OperatorGroupId = 0;
            GroupName = "%";
        }
        /// <summary>
        /// Annotation for getting the property name in DAL
        /// Primary key in SQL
        /// </summary>      
        [Key]
        public int OperatorGroupId { get; set; }
        
        /// <summary>
        /// Name of the group category
        /// </summary>
        public string GroupName { get; set; }
    }
}
