using System.ComponentModel.DataAnnotations;

namespace HouseRentAPI.Models
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string County { get; set; }
    }
}
