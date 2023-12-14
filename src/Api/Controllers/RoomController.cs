using Api.Commons;
using Application.Rooms.Commands.CreateRoom;
using Application.Rooms.Commands.DeleteRoom;
using Application.Rooms.Commands.UpdateRoom;
using Application.Rooms.Queries.GetAllRoom;
using Contracts.Room;
using Contracts.Room.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

public class RoomController(ISender sender) : ApiController
{
    [HttpPost]
    public IActionResult CreateRoom(CreateRoomRequest request)
    {
        var result = sender.Send(new CreateRoomCommand(
            request.Name,
            request.Floor,
            request.BedCount,
            request.Amount,
            request.Currency)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(new RoomResponse(
                    result.Value.Room.Id.Value,
                    result.Value.Room.Name,
                    result.Value.Room.IsReserved,
                    result.Value.Room.Floor.Name,
                    result.Value.Room.BedCount,
                    result.Value.Room.Price.Amount,
                    result.Value.Room.Price.Currency));
    }

    [HttpPut]
    public IActionResult UpdateRoom(UpdateRoomRequest request)
    {
        var result = sender.Send(new UpdateRoomCommand(
                    request.RoomId,
                    request.Name,
                    request.IsReserved,
                    request.Floor,
                    request.BedCount,
                    request.Amount,
                    request.Currency)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(new RoomResponse(
                    result.Value.Room.Id.Value,
                    result.Value.Room.Name,
                    result.Value.Room.IsReserved,
                    result.Value.Room.Floor.Name,
                    result.Value.Room.BedCount,
                    result.Value.Room.Price.Amount,
                    result.Value.Room.Price.Currency));
    }

    [HttpDelete("{roomId}")]
    public IActionResult DeleteRoom(Guid roomId)
    {
        var result = sender.Send(new DeleteRoomCommand(roomId)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok();
    }

    [HttpGet("get-all")]
    [AllowAnonymous]
    public IActionResult GetAllRoom()
    {
        var result = sender.Send(new GetAllRoomQuery()).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var rooms = result.Value.Rooms;
        var responses = new List<RoomResponse>();

        foreach (var room in rooms)
        {
            var response = new RoomResponse(
            room.Id.Value,
            room.Name,
            room.IsReserved,
            room.Floor.Name,
            room.BedCount,
            room.Price.Amount,
            room.Price.Currency);
            responses.Add(response);
        }

        return Ok(responses);
    }
}
