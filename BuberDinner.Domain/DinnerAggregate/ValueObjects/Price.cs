using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class Price : ValueObject
{

    public float Value { get; }

    private Price(float value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Price Create(float value)
    {
        return new Price(value);
    }
}
