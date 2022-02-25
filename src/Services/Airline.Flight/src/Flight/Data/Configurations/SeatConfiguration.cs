using Flight.Flight.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.Data.Configurations;

public class SeatConfiguration : IEntityTypeConfiguration<Flight.Models.Seat>
{
    public void Configure(EntityTypeBuilder<Flight.Models.Seat> builder)
    {
        builder.ToTable("Seat", "dbo");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();

        builder
            .HasOne<Flight.Models.Flight>()
            .WithMany()
            .HasForeignKey(p => p.FlightId);
    }
}
