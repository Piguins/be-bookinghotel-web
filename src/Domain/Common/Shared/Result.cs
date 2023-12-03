using Domain.Common.Exceptions;

namespace Domain.Common.Shared;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
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
