using BuberDinner.Application.Common.Interfaces;

namespace BuberDinner.Infrastructure.Services;

internal class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
