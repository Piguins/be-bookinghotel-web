using Api.Commons;
using Application.Rooms.Commands.CreateRoom;
using Application.Rooms.Commands.DeleteRoom;
using Application.Rooms.Commands.UpdateRoom;
using Application.Rooms.Queries.GetAllRoom;
using Contracts.Room;
using Contracts.Room.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Api.Controllers;

public class RoomController(ISender sender, IMapper mapper) : ApiController
{
    [HttpPost]
    public IActionResult CreateRoom(CreateRoomRequest request)
    {
        var result = sender
            .Send(
                new CreateRoomCommand(
                    request.Name,
                    request.Description,
                    request.Floor,
                    request.BedCount,
                    request.Amount,
                    request.Currency,
                    request.Images
                )
            )
            .Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(mapper.Map<RoomResponse>(result.Value));
    }

    [HttpPut]
    public IActionResult UpdateRoom(UpdateRoomRequest request)
    {
        var result = sender
            .Send(
                new UpdateRoomCommand(
                    request.RoomId,
                    request.Name,
                    request.Description,
                    request.IsReserved,
                    request.Floor,
                    request.BedCount,
                    request.Amount,
                    request.Currency,
                    request.Images
                )
            )
            .Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(mapper.Map<RoomResponse>(result.Value));
    }

    [HttpDelete("{roomId}")]
    public IActionResult DeleteRoom(Guid roomId)
    {
        var result = sender.Send(new DeleteRoomCommand(roomId)).Result;

        return result.IsFailure ? HandleFailure(result) : Ok();
    }

    [HttpGet("get-all")]
    [AllowAnonymous]
    public IActionResult GetAllRoom()
    {
        var result = sender.Send(new GetAllRoomQuery()).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(result.Value.Select(mapper.Map<RoomResponse>));
    }
}
