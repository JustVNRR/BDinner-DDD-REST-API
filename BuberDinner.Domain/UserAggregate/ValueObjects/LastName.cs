using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;

public sealed class LastName : ValueObject
{
    public string Value { get; private set; }

    private LastName(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static LastName Create(string value)
    {
        return new LastName(value);
    }
}
