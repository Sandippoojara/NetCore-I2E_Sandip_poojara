using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace NetCore_I2E_Sandip_poojara.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
