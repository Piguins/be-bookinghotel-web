using Api.Commons;
using Application.Rooms.Commands.CreateRoom;
using Application.Rooms.Commands.DeleteRoom;
using Application.Rooms.Commands.UpdateRoom;
using Application.Rooms.Queries.GetAllRoom;
using Application.Rooms.Queries.GetRoomByRoomTypeId;
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
        var result = sender.Send(new CreateRoomCommand(request.RoomTypeId, request.Name)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(new RoomResponse(
                    result.Value.Room.Id.Value,
                    result.Value.Room.RoomTypeId.Value,
                    result.Value.Room.IsReserved,
                    result.Value.Room.Name));
    }

    [HttpPut]
    public IActionResult UpdateRoom(UpdateRoomRequest request)
    {
        var result = sender.Send(new UpdateRoomCommand(request.RoomId, request.RoomTypeId, request.Name, request.IsReserved)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var room = result.Value.Room;
        var response = new RoomResponse(room.Id.Value, room.RoomTypeId.Value, room.IsReserved, room.Name);

        return Ok(response);
    }

    [HttpDelete]
    public IActionResult DeleteRoom(DeleteRoomRequest request)
    {
        var result = sender.Send(new DeleteRoomCommand(request.RoomId)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var room = result.Value.Room;
        var response = new RoomResponse(room.Id.Value, room.RoomTypeId.Value, room.IsReserved, room.Name);

        return Ok(response);
    }

    [HttpGet("RoomType/{roomTypeId}")]
    public IActionResult GetRoomByRoomTypeId(string roomTypeId)
    {
        var result = sender.Send(new GetRoomByRoomTypeIdQuery(roomTypeId)).Result;

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
            room.RoomTypeId.Value,
            room.IsReserved,
            room.Name);
            responses.Add(response);
        }

        return Ok(responses);
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
            room.RoomTypeId.Value,
            room.IsReserved,
            room.Name);
            responses.Add(response);
        }

        return Ok(responses);
    }
}
