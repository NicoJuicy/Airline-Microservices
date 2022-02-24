using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.Data.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<Flight.Models.Flight>
{
    public void Configure(EntityTypeBuilder<Flight.Models.Flight> builder)
    {
        builder.ToTable("Flight", "dbo");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();

        builder.OwnsOne(r => r.Aircraft, c =>
        {
            c.Property(r => r.Model);
            c.Property(r => r.Name);
        });

        builder.OwnsOne(r => r.ArriveAirport, c =>
        {
            c.Property(r => r.Code);
            c.Property(r => r.Name);
        });

        builder.OwnsOne(r => r.DepartureAirport, c =>
        {
            c.Property(r => r.Code);
            c.Property(r => r.Name);
        });
    }
}
