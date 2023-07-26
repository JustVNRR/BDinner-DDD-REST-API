using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.Entities;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate;

public class Guest : AggregateRoot<GuestId, Guid>
{
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<GuestRating> _guestRatings = new();

    public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyCollection<BillId> BillIds => _billIds.AsReadOnly();
    public UserId UserId { get; private set; } = default!;
    public MenuReviewId MenuReviewId { get; private set; } = default!;
    public IReadOnlyCollection<GuestRating> GuestRatings => _guestRatings.AsReadOnly();

    private Guest()
    {

    }
    private Guest(GuestId guestId, UserId userId, MenuReviewId menuReviewId) : base(guestId)
    {
        UserId = userId;
        MenuReviewId = menuReviewId;
    }

    private Guest(GuestId guestId, List<DinnerId> dinnerIds, List<BillId> billIds, List<GuestRating> guestRatings, UserId userId, MenuReviewId menuReviewId) : base(guestId)
    {
        _dinnerIds = dinnerIds;
        _billIds = billIds;
        _guestRatings = guestRatings;
        UserId = userId;
        MenuReviewId = menuReviewId;
    }

    public static Guest Create(GuestId guestId, UserId userId, MenuReviewId menuReviewId)
    {
        return new Guest(guestId, userId, menuReviewId);
    }

    public static Guest Create(GuestId guestId, List<DinnerId> dinnerIds, List<BillId> billIds, List<GuestRating> guestRatings, UserId userId, MenuReviewId menuReviewId)
    {
        return new Guest(guestId, dinnerIds, billIds, guestRatings, userId, menuReviewId);
    }
}
