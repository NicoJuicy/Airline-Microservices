using System.Reflection;
using Flight.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight.Infrastructure.Data
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Core.Models.Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Aircraft> Aircraft { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}