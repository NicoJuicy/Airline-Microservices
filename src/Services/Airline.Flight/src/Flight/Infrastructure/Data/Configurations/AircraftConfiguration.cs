using Flight.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.Infrastructure.Data.Configurations;

public class AircraftConfiguration: IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.ToTable("Aircraft", "dbo");

        builder.HasKey(r => r.Id);
    }
}