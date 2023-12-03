namespace Domain.Common.Shared;

public interface IValidationResult
{
    public static readonly Error ValidationError = new("ValidationError", "The value is invalid.");

    Error[] Errors { get; }
}
