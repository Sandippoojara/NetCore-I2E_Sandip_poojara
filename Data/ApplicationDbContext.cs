using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace NetCore_I2E_Sandip_poojara.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }

    }
}
