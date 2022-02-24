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

        // https://docs.microsoft.com/en-us/ef/core/modeling/shadow-properties
        // https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities
        builder.OwnsMany(p => p.Seats, a =>
        {
            a.WithOwner().HasForeignKey("AircraftId");
            a.Property<long>("Id");
            a.HasKey("Id");
            a.Property<long>("AircraftId");
            a.ToTable("Seat");
        });
    }
}
