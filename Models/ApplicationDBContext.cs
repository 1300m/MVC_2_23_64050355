using Microsoft.EntityFrameworkCore;

namespace MVCTest.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Karaoke> Karaokes { get; set; }
    }
}
