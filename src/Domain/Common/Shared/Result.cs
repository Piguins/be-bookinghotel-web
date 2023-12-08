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

    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Failure<TValue>(Error error) => new(false, error, default);
}

// ResultT
public class Result<TValue>(bool isSuccess, Error error, TValue? value) : Result(isSuccess, error)
{
    public TValue Value =>
        IsSuccess
            ? value!
            : throw new InvalidOperationException("The value of a failure result can not be accessed");

    public static implicit operator Result<TValue>(TValue? value)
    {
        return new Result<TValue>(true, Error.None, value);
    }

    // public static implicit operator Result<TValue>(Error error)
    // {
    //     return new Result<TValue>(false, error, default);
    // }
}
