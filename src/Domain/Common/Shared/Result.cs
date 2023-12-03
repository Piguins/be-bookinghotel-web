namespace Domain.Common.Shared;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if (
            (isSuccess && error != Error.None)
            || (!isSuccess && error == Error.None)
        )
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(true, error);
}

// ResultT
public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected Result(bool isSuccess, Error error, TValue? value)
        : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value =>
        IsSuccess
            ? _value!
            : throw new InvalidOperationException( "The value of a failure result can not be accessed"
            );

    public static implicit operator Result<TValue>(TValue? value)
    {
        return new Result<TValue>(true, Error.None, value);
    }
}
