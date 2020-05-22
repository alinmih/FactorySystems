using FactorySystems.CommonLibrary.PersistanceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactorySystems.CommonLibrary.ViewModels
{
    public class DepartmentVM
    {
        public DepartmentVM()
        {
            DepartmentId = 0;
            PlantId = 0;
            Name = "%";
            Description = "%";
        }

        public DepartmentVM(DepartmentModel model)
        {
            DepartmentId = model.DepartmentId;
            PlantId = model.PlantId;
            Name = model.Name;
            Description = model.Description;
        }
        /// <summary>
        /// Annotation for getting the property name in DAL
        /// Primary key in SQL
        /// </summary>     
        public int DepartmentId { get; set; }

        /// <summary>
        /// Id of the plant in department table
        /// Foreign key
        /// </summary>
        [Required]
        public int PlantId { get; set; }

        /// <summary>
        /// Name of the department
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description of the department
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Reference to plant model
        /// </summary>
        public PlantVM Plant { get; set; }
    }
}
