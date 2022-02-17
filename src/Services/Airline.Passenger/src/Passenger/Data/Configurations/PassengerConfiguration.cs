using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Passenger.Data.Configurations;

public class PassengerConfiguration: IEntityTypeConfiguration<Passenger.Models.Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger.Models.Passenger> builder)
    {
        builder.ToTable("Passenger", "dbo");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();
    }
}