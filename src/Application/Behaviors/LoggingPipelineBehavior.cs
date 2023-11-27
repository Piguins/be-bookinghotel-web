using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors;

public class LoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
                "Starting request {@RequestName} {@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow);

        var result = await next();

        // if (result is null)
        // {
        //     _logger.LogError(
        //             "Error in request {@RequestName} {@Error} {@DateTimeUtc}",
        //             typeof(TRequest).Name,
        //             null,
        //             DateTime.UtcNow);
        // }

        _logger.LogInformation(
                "Completed request {@RequestName} {@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow);

        return result;
    }
}
