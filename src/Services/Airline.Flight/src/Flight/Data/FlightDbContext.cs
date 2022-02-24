using System.Reflection;
using Flight.Flight.Models.ValueObjects;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
