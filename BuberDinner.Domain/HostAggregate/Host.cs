using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate;

public class Host : AggregateRoot<HostId, Guid>
{
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuId> _menuIds = new();

    public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyCollection<MenuId> MenuIds => _menuIds.AsReadOnly();

    public UserId UserId { get; private set; } = default!;

    private Host()
    {

    }

    private Host(HostId hostId, List<DinnerId> dinnerIds, List<MenuId> menuIds, UserId userId) : base(hostId)
    {
        _dinnerIds = dinnerIds;
        _menuIds = menuIds;
        UserId = userId;
    }
    public static Host Create(List<DinnerId> dinnerIds, List<MenuId> menuIds, UserId userId)
    {
        return new Host(HostId.CreateUnique(), dinnerIds, menuIds, userId);
    }
}


