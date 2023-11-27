using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Abstractions;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected ISender Sender { get; }

    protected ApiController(ISender sender)
    {
        Sender = sender;
    }
}
