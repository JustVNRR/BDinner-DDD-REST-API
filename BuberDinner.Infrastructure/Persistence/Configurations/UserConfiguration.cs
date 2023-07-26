using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value));

        builder.Property(u => u.HostId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => HostId.Create(value));

        builder.Property(u => u.GuestId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => GuestId.Create(value));

        builder.Property(u => u.FirstName)
            .HasMaxLength(100)
            .HasConversion(id => id.Value, value => FirstName.Create(value));

        builder.Property(u => u.LastName)
            .HasMaxLength(100)
            .HasConversion(id => id.Value, value => LastName.Create(value));

        builder.Property(u => u.Email)
            .HasMaxLength(100)
            .HasConversion(id => id.Value, value => Email.Create(value));

        builder.Property(u => u.Password)
            .HasMaxLength(100)
            .HasConversion(id => id.Value, value => Password.Create(value));
    }
}
