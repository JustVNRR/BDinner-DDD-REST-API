using BuberDinner.Domain.HostAggregate;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class HostConfiguration : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostsTable(builder);
        ConfigureHostDinnerIdsTable(builder);
        ConfigureHostMenuIdsTable(builder);
    }

    private void ConfigureHostsTable(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");

        builder.Property(h => h.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => HostId.Create(value));

        builder.Property(h => h.UserId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value));
    }

    private void ConfigureHostDinnerIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.DinnerIds, dib =>
        {
            dib.ToTable("HostDinnerIds");
            dib.WithOwner().HasForeignKey("HostId");
            dib.HasKey("Id");

            dib.Property(d => d.Value)
            .HasColumnName("DinnerId")
            .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }


    private void ConfigureHostMenuIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(m => m.MenuIds, mib =>
        {
            mib.ToTable("HostMenuIds");
            mib.WithOwner().HasForeignKey("HostId");
            mib.HasKey("Id");

            mib.Property(d => d.Value)
            .HasColumnName("MenuId")
            .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Host.MenuIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
