using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace ParkingSystem.Data.Models
{
    public class Car
    {
        public DateTime TimeCreated { get; } = DateAndTime.Now;
        [Required]
        public string CarMake { get; set; }
        [Required]
        public string PlateNumber { get; set; }
    }
}
