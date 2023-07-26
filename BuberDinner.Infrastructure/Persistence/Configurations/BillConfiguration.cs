using BuberDinner.Domain.BillAggregate;
using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");

        builder.Property(b => b.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => BillId.Create(value));

        builder.Property(b => b.HostId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => HostId.Create(value));

        builder.Property(b => b.GuestId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => GuestId.Create(value));

        builder.Property(b => b.DinnerId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => DinnerId.Create(value));
    }
}
