using Microsoft.EntityFrameworkCore;

namespace Uber.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ride> Rides    { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Vehicle> Vehicles  { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(e => e.Vehicle)
                .WithOne(e => e.Driver)
                .HasForeignKey<Vehicle>(e => e.DriverId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.DriverRides)
                .WithOne(e => e.Driver)
                .HasForeignKey(e => e.DriverId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.RiderRides)
                .WithOne(e => e.Rider)
                .HasForeignKey(e => e.RiderId);
            modelBuilder.Entity<Ride>()
                .HasOne(e => e.Payment)
                .WithOne(e => e.Ride)
                .HasForeignKey<Payment>(e => e.RideId);
            modelBuilder.Entity<Ride>()
                .HasOne(e => e.Rating)
                .WithOne(e => e.Ride)
                .HasForeignKey<Rating>(e => e.RideId);

            modelBuilder.Entity<User>().HasData
                (
                    new User { Id = 1, FullName = "rider1", Password = "123", Phone = "123456789", Role = "Rider" },
                    new User { Id = 2, FullName = "driver1", Password = "123", Phone = "123446789", Role = "Driver" }
                );
            modelBuilder.Entity<Vehicle>().HasData
                (
                    new Vehicle { Id = 1, Color = "blue", DriverId = 2, PlateNumber = "11111" }
                );
            modelBuilder.Entity<Ride>().HasData
                (
                    new Ride { Id = 1, DriverId = 2, Fare = 111, PickOffLocation = "aa", PickupLocation = "pickup1", RiderId = 1, Status = "Complete" }
                );
        }
    }
}
