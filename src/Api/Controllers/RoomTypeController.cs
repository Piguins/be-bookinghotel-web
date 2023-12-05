using Api.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("Roomtype")]
public class RoomTypeController : ApiController
{
    public RoomTypeController(ISender sender) : base(sender)
    {
    }
}
