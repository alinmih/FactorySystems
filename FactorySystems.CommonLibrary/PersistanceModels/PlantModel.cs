using FactorySystems.CommonLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactorySystems.CommonLibrary.PersistanceModels
{
    /// <summary>
    /// Types of params from SQL:
    /// [PlantId] INT IDENTITY(1, 1) NOT NULL,
    /// [Name]    NVARCHAR(200) NOT NULL,
    /// [Address] NVARCHAR(200) NULL,
    /// [City] NVARCHAR(200) NULL,
    /// [Phone] NVARCHAR(20)  NULL,
    /// [Email] NVARCHAR(200) NULL,
    /// </summary>
    public class PlantModel
    {
        /// <summary>
        /// Default constructor to initialize the properties with default value
        /// </summary>
        public PlantModel()
        {
            //PlantId = 0;
            //Name = "%";
            //Address = "%";
            //City = "%";
            //Phone = "%";
            //Email = "%";
        }

        public PlantModel(PlantVM model)
        {
            PlantId = model.PlantId;
            Name = model.Name;
            Address = model.Address;
            City = model.City;
            Phone = model.Phone;
            Email = model.Email;
        }
        /// <summary>
        /// Annotation for getting the property name in DAL
        /// Primary key in SQL
        /// </summary>        
        [Key]
        public int PlantId { get; set; }
        /// <summary>
        /// Name of the plant
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Address of the plant
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// City of the plant
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Phone number
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Email Address
        /// </summary>
        public string Email { get; set; }

    }
}
