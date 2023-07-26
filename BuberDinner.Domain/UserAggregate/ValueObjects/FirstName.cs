using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;

public sealed class FirstName : ValueObject
{
    public string Value { get; private set; }

    private FirstName(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static FirstName Create(string value)
    {
        return new FirstName(value);
    }
}
