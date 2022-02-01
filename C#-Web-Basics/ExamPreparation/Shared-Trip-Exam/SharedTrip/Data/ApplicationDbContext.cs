namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserTrip>(e =>
            {
                e.HasKey(ut => new { ut.UserId, ut.TripId });
            });
        }
    }
}
