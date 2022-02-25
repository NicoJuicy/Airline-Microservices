using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Flight.Data
{
    public sealed class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Flight.Models.Flight> Flights => Set<Flight.Models.Flight>();
        public DbSet<Airport.Models.Airport> Airports => Set<Airport.Models.Airport>();
        public DbSet<Aircraft.Models.Aircraft> Aircraft => Set<Aircraft.Models.Aircraft>();
        public DbSet<Flight.Models.Seat> Seats => Set<Flight.Models.Seat>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
