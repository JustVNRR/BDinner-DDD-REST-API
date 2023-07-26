using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.BillAggregate;

public class Bill : AggregateRoot<BillId, Guid>
{
    public DinnerId DinnerId { get; private set; } = default!;
    public GuestId GuestId { get; private set; } = default!;
    public HostId HostId { get; private set; } = default!;

    private Bill()
    {

    }
    private Bill(BillId billId, DinnerId dinnerId, GuestId guestId, HostId hostId) : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
    }

    public static Bill Create(DinnerId dinnerId, GuestId guestId, HostId hostId)
    {
        return new Bill(BillId.CreateUnique(), dinnerId, guestId, hostId);
    }
}
