using Microsoft.EntityFrameworkCore;

namespace MyPersonasBackEnd.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            :base(options)
        {

        }

        public DbSet<Testee> Testees { get; set;}

    }
}
