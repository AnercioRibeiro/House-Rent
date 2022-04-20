using HouseRentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Anouncement> Anouncements { get; set; }
        public DbSet<UserAnouncement> UserAnouncements { get; set; }
        public DbSet<UserTenant> UserTenants { get; set; }
        public DbSet<Province> Provinces { get; set; }
    }

}

