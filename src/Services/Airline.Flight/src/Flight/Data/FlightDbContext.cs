using System.Reflection;
using Flight.Flight.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight.Data
{
    public sealed class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Flight.Models.Flight> Flights => Set<Flight.Models.Flight>();
        public DbSet<Airport> Airports => Set<Airport>();
        public DbSet<Aircraft> Aircraft  => Set<Aircraft>();
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}