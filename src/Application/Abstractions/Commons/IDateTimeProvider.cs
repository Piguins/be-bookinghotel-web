namespace Application.Abstractions.Commons;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
