namespace Domain.Common.Shared;

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(bool isSuccess, BaseError domainError, TValue? value)
        : base(isSuccess, domainError)
    {
        _value = value;
    }

    public TValue Value =>
        IsSuccess
            ? _value!
            : throw new InvalidOperationException(
                "The value of a failure result can not be accessed"
            );

    public static implicit operator Result<TValue>(TValue? value)
    {
        return new(true, BaseError.None, value);
    }
}
