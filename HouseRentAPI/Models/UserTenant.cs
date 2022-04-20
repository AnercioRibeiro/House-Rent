using System.ComponentModel.DataAnnotations;

namespace HouseRentAPI.Models
{
    public class UserTenant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public enum GenderType { Masculino, Femenino }
        public GenderType Gender { get; set; }

    }
}
