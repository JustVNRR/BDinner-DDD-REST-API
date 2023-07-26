namespace BuberDinner.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvent where TId : ValueObject
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public TId Id { get; protected set; } = default!;

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected Entity()
    {
    }

    protected Entity(TId id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> other &&
               EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right) { return Equals(left, right); }
    public static bool operator !=(Entity<TId> left, Entity<TId> right) { return !Equals(left, right); }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
