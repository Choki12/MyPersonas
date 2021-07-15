using Microsoft.EntityFrameworkCore;

namespace MyPersonasBackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Testee>()
                .HasIndex(t => t.UserName)
                .IsUnique();  //When we migrate our DB, the Testee will have a unique UserName in our DataModel

            /*
             * Define our many to many relationships
             */

            modelBuilder.Entity<TesteeTest>()
                .HasKey(tt => new {tt.TesteeId, tt.TestId});

            modelBuilder.Entity<TestQuestion>()
              .HasKey(tq => new { tq.TestId, tq.QuestionId });
        }

        public DbSet<Testee> Testees { get; set;}
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Test> Test { get; set; }


    }
}
