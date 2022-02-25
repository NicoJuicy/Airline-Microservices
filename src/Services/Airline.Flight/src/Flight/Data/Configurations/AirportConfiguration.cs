using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.Data.Configurations;

public class AirportConfiguration: IEntityTypeConfiguration<Airport.Models.Airport>
{
    public void Configure(EntityTypeBuilder<Airport.Models.Airport> builder)
    {
        builder.ToTable("Airport", "dbo");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();
    }
}
