using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactorySystems.CommonLibrary.PersistanceModels
{
    /// <summary>
    /// Types of params from SQL:
    /// MachineCategoryId int IDENTITY,
    /// Category nvarchar(50) NOT NULL,
    /// </summary>
    public class MachineCategoryModel
    {

        public MachineCategoryModel()
        {
            MachineCategoryId = 0;
            Category = "%";
        }
        /// <summary>
        /// Annotation for getting the property name in DAL
        /// Primary key in SQL
        /// </summary>      
        [Key]
        public int MachineCategoryId { get; set; }

        /// <summary>
        /// Name of the machine category
        /// </summary>
        public string Category { get; set; }
    }
}
