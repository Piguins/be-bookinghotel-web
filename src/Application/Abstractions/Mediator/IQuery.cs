using MediatR;

namespace Application.Abstractions.Mediator;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
