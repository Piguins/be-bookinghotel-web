using Application.Abstractions.Commons;

namespace Infrastructure.Services.Commons;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
