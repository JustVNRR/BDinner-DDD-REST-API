using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        ConfigureGuestsTable(builder);
        ConfigureGuestDinnerIdsTable(builder);
        ConfigureGuestBillIdsTable(builder);
        ConfigureGuestRatingsTable(builder);
    }

    private void ConfigureGuestRatingsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(d => d.GuestRatings, rb =>
        {
            rb.ToTable("GuestRatings");

            rb.WithOwner().HasForeignKey("GuestId");

            rb.HasKey("Id", "GuestId");

            rb.Property(g => g.Id)
            .ValueGeneratedNever()
    .       HasConversion(id => id.Value, value => GuestRatingId.Create(value));

            rb.Property(r => r.HostId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => HostId.Create(value));

            rb.Property(r => r.DinnerId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => DinnerId.Create(value));
        });

        builder.Metadata.FindNavigation(nameof(Guest.GuestRatings))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.Property(g => g.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => GuestId.Create(value));

        builder.Property(g => g.UserId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value));

        builder.Property(g => g.MenuReviewId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => MenuReviewId.Create(value));
    }

    private void ConfigureGuestDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.DinnerIds, dib =>
        {
            dib.ToTable("GuestDinnerIds");
            dib.WithOwner().HasForeignKey("GuestId");
            dib.HasKey("Id");

            dib.Property(d => d.Value)
            .HasColumnName("DinnerId")
            .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Guest.DinnerIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }


    private void ConfigureGuestBillIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.BillIds, bib =>
        {
            bib.ToTable("GuestBillIds");
            bib.WithOwner().HasForeignKey("GuestId");
            bib.HasKey("Id");

            bib.Property(d => d.Value)
            .HasColumnName("BillId")
            .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Guest.BillIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
