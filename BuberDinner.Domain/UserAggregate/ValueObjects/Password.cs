using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;

public sealed class Password : ValueObject
{
    public string Value { get; private set; }

    private Password(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Password Create(string value)
    {
        return new Password(value);
    }
}
