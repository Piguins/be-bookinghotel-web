using Domain.Common.Shared;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(
        ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger,
        IEnumerable<IValidator<TRequest>> validators)
    {
        _logger = logger;
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        // TODO: Validate request
        Error[] errors = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error is not null)
            .Select(error => new Error(error.PropertyName, error.ErrorMessage))
            .Distinct()
            .ToArray();

        // TODO: If request is invalid, return Errors
        if (errors.Any())
        {
            return CreateValidationResult<TResponse>(errors);
        }

        // TODO: If request is valid, continue to next handler
        return await next();
    }

    private TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Result
    {
        if (typeof(TResult) == typeof(ValidationResult))
        {
            return (ValidationResult.WithErrors(errors) as TResult)!;
        }

        object validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GetGenericArguments()[0])
            .GetMethod(nameof(ValidationResult.WithErrors))!
            .Invoke(null, new object[] { errors })!;

        return (TResult)validationResult;
    }
}
