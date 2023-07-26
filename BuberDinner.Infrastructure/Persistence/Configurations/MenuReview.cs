using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class MenuReviewConfiguration : IEntityTypeConfiguration<MenuReview>
{
    public void Configure(EntityTypeBuilder<MenuReview> builder)
    {
        builder.ToTable("MenuReviews");

        builder.Property(mr => mr.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => MenuReviewId.Create(value));

        builder.Property(mr => mr.HostId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => HostId.Create(value));

        builder.Property(mr => mr.GuestId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => GuestId.Create(value));

        builder.Property(mr => mr.MenuId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => MenuId.Create(value));
    }
}
