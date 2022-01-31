using Flight.Flight.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.Data.Configurations;

public class FlightTypeConfiguration: IEntityTypeConfiguration<Flight.Models.Flight>
{
    public void Configure(EntityTypeBuilder<Flight.Models.Flight> builder)
    {
        builder.ToTable("Flight", "dbo");

        builder.HasKey(r => r.Id);
        
        builder
            .HasOne<Aircraft>()
            .WithMany()
            .HasForeignKey(p => p.AircraftId);
        
        builder
            .HasOne<Airport>()
            .WithMany()
            .HasForeignKey(d => d.DepartureAirportId)
            .HasForeignKey(a => a.ArriveAirportId);
    }
}