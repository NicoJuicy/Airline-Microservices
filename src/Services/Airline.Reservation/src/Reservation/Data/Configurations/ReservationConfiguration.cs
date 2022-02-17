using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reservation.Data.Configurations;

public class ReservationConfiguration: IEntityTypeConfiguration<Reservation.Models.Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation.Models.Reservation> builder)
    {
        builder.ToTable("Reservation", "dbo");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();
        
        builder.OwnsOne(c => c.Journey, x =>
        {
            x.Property(c => c.Description);
            x.Property(c => c.ArriveDate);
            x.Property(c => c.DepartureDate);
            x.Property(c => c.FlightId);
            x.Property(c => c.ArriveAirportId);
            x.Property(c => c.DepartureAirportId);
        });
        
        builder.OwnsOne(c => c.PassengerInfo, x =>
        {
            x.Property(c => c.Name);
            x.Property(c => c.PassengerId);
        });
    }
}