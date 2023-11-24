namespace Domain.Common.Shared;

public class BaseError : IEquatable<BaseError>
{
    public static readonly BaseError None = new(string.Empty);
    public static readonly BaseError NullValue =
        new("Error.NullValue", "The specified result value is null.");

    public BaseError(string code, string? message = null)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string? Message { get; }

    public static implicit operator Result(BaseError domainError)
    {
        return Result.Failure(domainError);
    }

    public static implicit operator string(BaseError domainError)
    {
        return domainError.Code;
    }

    public static bool operator ==(BaseError? first, BaseError? second)
    {
        return (first is null && second is null)
            || (first is not null && second is not null && first.Equals(second));
    }

    public static bool operator !=(BaseError? first, BaseError? second)
    {
        return !(first == second);
    }

    public bool Equals(BaseError? other) =>
        other is not null && other.GetType() == GetType() && other.Code == Code;

    public override bool Equals(object? obj) =>
        obj is not null
        && obj.GetType() == GetType()
        && obj is BaseError entity
        && entity.Code == Code;

    public override int GetHashCode() => throw new NotImplementedException();
}
