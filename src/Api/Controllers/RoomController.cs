using Api.Abstractions;
using Application.Rooms.Commands.CreateRoom;
using Application.Rooms.Commands.DeleteRoom;
using Application.Rooms.Commands.UpdateRoom;
using Application.Rooms.Queries.GetAllRoom;
using Application.Rooms.Queries.GetRoomByRoomTypeId;
using Contracts.Booking.Queries;
using Contracts.Room;
using Contracts.Room.Commands;
using Contracts.Room.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class RoomController(ISender sender) : ApiController
{
    [HttpPost("create")]
    public IActionResult CreateRoom(CreateRoomRequest request)
    {
        var result = sender.Send(new CreateRoomCommand(request.RoomTypeId, request.Name, request.IsReserved)).Result;

        if(result.IsFailure)
        {
            HandleFailure(result);
        }

        var room = result.Value.Room;
        var response = new RoomResponse(room.Id.Value, room.RoomTypeId.Value, room.IsReserved, room.Name);

        return Ok(response);
    }

    [HttpPut("update")]
    public IActionResult UpdateRoom(UpdateRoomRequest request)
    {
        var result = sender.Send(new UpdateRoomCommand(request.RoomId, request.RoomTypeId, request.Name, request.IsReserved)).Result;

        if (result.IsFailure)
        {
            HandleFailure(result);
        }

        var room = result.Value.Room;
        var response = new RoomResponse(room.Id.Value, room.RoomTypeId.Value, room.IsReserved, room.Name);

        return Ok(response);
    }

    [HttpDelete("delete")]
    public IActionResult DeleteRoom(DeleteRoomRequest request)
    {
        var result = sender.Send(new DeleteRoomCommand(request.RoomId)).Result;

        if (result.IsFailure)
        {
            HandleFailure(result);
        }

        var room = result.Value.Room;
        var response = new RoomResponse(room.Id.Value, room.RoomTypeId.Value, room.IsReserved, room.Name);

        return Ok(response);
    }

    [HttpGet("roomtype")]
    public IActionResult GetRoomByRoomTypeId(GetRoomByRoomTypeIdRequest request)
    {
        var result = sender.Send(new GetRoomByRoomTypeIdQuery(request.RoomTypeId)).Result;

        if (result.IsFailure)
        {
            HandleFailure(result);
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

        return Ok(new RoomList(responses));
    }

    [HttpGet]
    public IActionResult GetAllRoom(GetAllBookingsRequest request)
    {
        var result = sender.Send(new GetAllRoomQuery()).Result;

        if (result.IsFailure)
        {
            HandleFailure(result);
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

        return Ok(new RoomList(responses));
    }
}
