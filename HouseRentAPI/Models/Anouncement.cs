using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRentAPI.Models
{
    public class Anouncement
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int Identifier { get; set; }
        [Required]
        public string Description { get; set; }
        public enum TypologyType { T1, T2, T3, T4, T5, T6, T7 }
        [Required]
        public TypologyType Typology { get; set;}
        public string Floor { get; set; }
        [Required]
        public string Elevator { get; set; }
        public string Dimension { get; set; }
        [Required]
        public string Parking { get; set; }
        [Required]
        public string WaterFount { get; set; }
        
        public enum Energy { PrePago, PosPago, Gerador }
        [Required]
        public Energy EnergyType { get; set; }
        [Required]
        public int SuiteNumber { get; set; }
        public enum HouseType { Apartamento, Vivenda, }
        [Required]
        public HouseType HouseTypology { get; set; }
        [Required]
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province Province { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinishDate { get; set; }
        public byte[] Picture { get; set; }

    }
}
