﻿using FactorySystems.CommonLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactorySystems.CommonLibrary.PersistanceModels
{
    /// <summary>
    /// Types of params from SQL:
    /// [DepartmentId] INT IDENTITY (1, 1) NOT NULL,
    /// [PlantId] INT NOT NULL,
    /// [Name] NVARCHAR(200)  NOT NULL,
    /// [Description]  NVARCHAR(4000) NULL,
    /// </summary>
    public class DepartmentModel
    {
        /// <summary>
        /// Default constructor to initialize the properties with default value
        /// </summary>
        public DepartmentModel()
        {
            DepartmentId = 0;
            PlantId = 0;
            Name = "%";
            Description = "%";
        }

        public DepartmentModel(DepartmentVM model)
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
        [Key]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Id of the plant in department table
        /// Foreign key
        /// </summary>
        public int PlantId { get; set; }

        /// <summary>
        /// Name of the department
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the department
        /// </summary>
        public string Description { get; set; }
    }
}
