using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reservation.Data.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation.Models.Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation.Models.Reservation> builder)
    {
        builder.ToTable("Reservation", "dbo");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();

        builder.OwnsOne(c => c.Trip, x =>
        {
            x.Property(c => c.Description);
            x.Property(c => c.Price);
            x.Property(c => c.AircraftId);
            x.Property(c => c.FlightDate);
            x.Property(c => c.FlightNumber);
            x.Property(c => c.SeatNumber);
            x.Property(c => c.ArriveAirportId);
            x.Property(c => c.DepartureAirportId);
        });

        builder.OwnsOne(c => c.PassengerInfo, x =>
        {
            x.Property(c => c.Name);
        });
    }
}
