namespace Domain.Common.Shared;

public class Result
{
    protected internal Result(bool isSuccess, BaseError error)
    {
        if (
            (isSuccess && error != BaseError.None)
            || (!isSuccess && error == BaseError.None)
        )
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public BaseError Error { get; }

    public static Result Success() => new(true, BaseError.None);
    public static Result Failure(BaseError error) => new(true, error);
}
