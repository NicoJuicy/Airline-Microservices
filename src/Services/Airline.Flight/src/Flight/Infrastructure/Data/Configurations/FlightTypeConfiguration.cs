using Flight.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.Infrastructure.Data.Configurations;

public class FlightTypeConfiguration: IEntityTypeConfiguration<Core.Models.Flight>
{
    public void Configure(EntityTypeBuilder<Core.Models.Flight> builder)
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