using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.UserAggregate;

public class User : AggregateRoot<UserId, Guid>
{
    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;

    public GuestId GuestId { get; private set; } = default!;
    public HostId HostId { get; private set; } = default!;

    private User()
    {

    }

    private User(UserId id, FirstName firstName, LastName lastName, Email email, Password password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    private User(UserId id, FirstName firstName, LastName lastName, Email email, Password password, GuestId guestId, HostId hostId) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        GuestId = guestId;
        HostId = hostId;
    }

    public static User Create(FirstName firstName, LastName lastName, Email email, Password password)
    {
        return new User(UserId.CreateUnique(), firstName, lastName, email, password);
    }

    public static User Create(FirstName firstName, LastName lastName, Email email, Password password, GuestId guestId, HostId hostId)
    {
        return new User(UserId.CreateUnique(), firstName, lastName, email, password, guestId, hostId);
    }
}
