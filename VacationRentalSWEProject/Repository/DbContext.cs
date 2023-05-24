using VacationRentalSWEProject.Model;
using Microsoft.EntityFrameworkCore;

namespace VacationRentalSWEProject.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<UserDestination> UserDestinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDestination>()
                .HasKey(ud => new { ud.UserID, ud.DestinationId });

            modelBuilder.Entity<UserDestination>()
                .HasOne(ud => ud.User)
                .WithMany(u => u.UserDestinations)
                .HasForeignKey(ud => ud.UserID);

            modelBuilder.Entity<UserDestination>()
                .HasOne(ud => ud.Destination)
                .WithMany(d => d.UserDestinations)
                .HasForeignKey(ud => ud.DestinationId);
        }
    }

}
