using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate;

public class Dinner : AggregateRoot<DinnerId, Guid>
{
    private readonly List<Reservation> _reservations = new();

    public HostId HostId { get; private set; } = default!;
    public MenuId MenuId { get; private set; } = default!;
    public IReadOnlyCollection<Reservation> Reservations => _reservations.AsReadOnly();

    private Dinner()
    {

    }
    private Dinner(DinnerId dinnerId, HostId hostId, MenuId menuId, List<Reservation> reservations) : base(dinnerId)
    {
        HostId = hostId;
        MenuId = menuId;
        _reservations = reservations;
    }

    public static Dinner Create(HostId hostId, MenuId menuId, List<Reservation> reservations)
    {
        return new Dinner(DinnerId.CreateUnique(), hostId, menuId, reservations);
    }
}
