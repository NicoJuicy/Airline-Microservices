using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.Data.Configurations;

public class AircraftConfiguration : IEntityTypeConfiguration<Aircraft.Models.Aircraft>
{
    public void Configure(EntityTypeBuilder<Aircraft.Models.Aircraft> builder)
    {
        builder.ToTable("Aircraft", "dbo");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();
    }
}
