namespace BuberDinner.Application.Common.Interfaces;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
    // DateTimeOffset Now { get; }
}
