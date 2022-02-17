using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Data;

public class ReservationDbContext: DbContext
{ 
    public ReservationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Reservation.Models.Reservation> Reservations => Set<Reservation.Models.Reservation>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}