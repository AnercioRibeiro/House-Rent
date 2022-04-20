using HouseRentAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRentAPI.Models
{
    public class UserAnouncement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AnouncementId { get; set; }
        [ForeignKey("AnouncementId")]
        public Anouncement Anouncement { get; set; }
        [Required]
        public int UserTenantId { get; set; }
        [ForeignKey("UserTenantId")]
        public UserTenant UserTenant { get; set; }

    }
}
