using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;

public class MenuReview : AggregateRoot<MenuReviewId, Guid>
{
    public MenuId MenuId { get; private set; } = default!;
    public GuestId GuestId { get; private set; } = default!;
    public HostId HostId { get; private set; } = default!;

    private MenuReview()
    {

    }
    private MenuReview(MenuReviewId menuReviewId, MenuId menuId, GuestId guestId, HostId hostId) :base(menuReviewId)
    {
        MenuId = menuId;
        GuestId = guestId;
        HostId = hostId;
    }

    public static MenuReview Create(MenuId menuId, GuestId guestId, HostId hostId)
    {
        return new MenuReview(MenuReviewId.CreateUnique(), menuId, guestId, hostId);
    }
}
