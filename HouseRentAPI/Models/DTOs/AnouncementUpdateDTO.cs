using System;
using System.ComponentModel.DataAnnotations;
using static HouseRentAPI.Models.Anouncement;

namespace HouseRentAPI.Models.DTOs
{
    public class AnouncementUpdateDTO
    {
        public int Id { get; set; }
       
        public int Identifier { get; set; }
        
        public string Description { get; set; }
        
        public TypologyType Typology { get; set; }
        public string Floor { get; set; }
        [Required]
        public string Elevator { get; set; }
        public string Dimension { get; set; }
        [Required]
        public string Parking { get; set; }
        [Required]
        public string WaterFount { get; set; }
       
        public Energy EnergyType { get; set; }
        [Required]
        public int SuiteNumber { get; set; }
        
        public HouseType HouseTypology { get; set; }
        [Required]
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinishDate { get; set; }
        public byte[] Picture { get; set; }
    }
}
