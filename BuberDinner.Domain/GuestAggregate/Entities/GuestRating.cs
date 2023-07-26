using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public DinnerId DinnerId { get; private set; } = default!;
    public HostId HostId { get; private set; } = default!;

    private GuestRating()
    {

    }

    private GuestRating(GuestRatingId guestRatingId, DinnerId dinnerId, HostId hostId) : base(guestRatingId)
    {
        DinnerId = dinnerId;
        HostId = hostId;
    }

    public static GuestRating Create(DinnerId dinnerId, HostId hostId)
    {
        return new GuestRating(GuestRatingId.CreateUnique(), dinnerId, hostId);
    }
}
