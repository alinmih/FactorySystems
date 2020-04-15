using FactorySystems.CommonLibrary.PersistanceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactorySystems.CommonLibrary.ViewModels
{
    public class PlantVM
    {
        public PlantVM()
        {
            PlantId = 0;
            Name = "%";
            Address = "%";
            City = "%";
            Phone = "%";
            Email = "%";
        }
        public PlantVM(PlantModel model)
        {
            PlantId = model.PlantId;
            Name = model.Name;
            Address = model.Address;
            City = model.City;
            Phone = model.Phone;
            Email = model.Email;
        }

        public int PlantId { get; set; }
        /// <summary>
        /// Name of the plant
        /// </summary>
        [Required]
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
