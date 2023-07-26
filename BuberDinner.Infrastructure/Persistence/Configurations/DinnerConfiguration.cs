using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class DinnerConfiguration : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigureDinnersTable(builder);
        ConfigureReservationsTable(builder);
    }

    private void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.ToTable("Dinners");

        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => DinnerId.Create(value));

        builder.Property(d => d.HostId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => HostId.Create(value));

        builder.Property(d => d.MenuId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => MenuId.Create(value));
    }

    private void ConfigureReservationsTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.OwnsMany(d => d.Reservations, rb =>
        {
            rb.ToTable("Reservations");

            rb.WithOwner().HasForeignKey("DinId");

            rb.HasKey("Id", "DinId");

            rb.Property(r => r.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => ReservationId.Create(value));

            rb.Property(r => r.GuestId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => GuestId.Create(value));

            rb.Property(r => r.BillId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => BillId.Create(value));

            /* rb.Property(r => r.DinnerId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => DinnerId.Create(value));*/

            rb.Ignore(r => r.DinnerId);
        });

        builder.Metadata.FindNavigation(nameof(Dinner.Reservations))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
