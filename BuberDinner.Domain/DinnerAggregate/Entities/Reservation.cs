using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public DinnerId DinnerId { get; private set; } = default!;
    public GuestId GuestId { get; private set; } = default!;
    public BillId BillId { get; private set; } = default!;

    private Reservation()
    {

    }
    private Reservation(ReservationId reservationId, DinnerId dinnerId, GuestId guestId, BillId billId) : base(reservationId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        BillId = billId;
    }

    public static Reservation Create(DinnerId dinnerId, GuestId guestId, BillId billId)
    {
        return new Reservation(ReservationId.CreateUnique(), dinnerId, guestId, billId);
    }
}
