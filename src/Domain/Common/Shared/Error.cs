namespace Domain.Common.Shared;

public class Error : IEquatable<Error>
{
    public static readonly Error None = new(string.Empty);
    public static readonly Error NullValue =
        new("Error.NullValue", "The specified result value is null.");

    public Error(string code, string? message = null)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string? Message { get; }

    public static implicit operator Result(Error error)
    {
        return Result.Failure(error);
    }

    public static implicit operator string(Error error)
    {
        return error.Code;
    }

    public static bool operator ==(Error? first, Error? second)
    {
        return (first is null && second is null)
            || (first is not null && second is not null && first.Equals(second));
    }

    public static bool operator !=(Error? first, Error? second)
    {
        return !(first == second);
    }

    public bool Equals(Error? other) =>
        other is not null && other.GetType() == GetType() && other.Code == Code;

    public override bool Equals(object? obj) =>
        obj is not null
        && obj.GetType() == GetType()
        && obj is Error entity
        && entity.Code == Code;

    public override int GetHashCode() => HashCode.Combine(Code);
}
