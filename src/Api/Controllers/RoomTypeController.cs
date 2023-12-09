using Api.Abstractions;
using Application.RoomTypes.Commands.CreateRoomType;
using Application.RoomTypes.Commands.DeleteRoomType;
using Application.RoomTypes.Queries.GetAllRoomType;
using Contracts.RoomType;
using Contracts.RoomType.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class RoomTypeController(ISender sender) : ApiController
{
    [HttpPost]
    public IActionResult CreateRoomType(CreateRoomTypeRequest request)
    {
        var result = sender.Send(new CreateRoomTypeCommand(
            request.Floor,
            request.BedCount,
            request.Amount,
            request.Currency)).Result;

        if (result.IsFailure)
        {
            HandleFailure(result);
        }

        var roomType = result.Value.RoomType;
        var response = new RoomTypeResponse(
            roomType.Id.Value,
            roomType.Floor.Name,
            roomType.BedCount,
            roomType.Price.Amount,
            roomType.Price.Currency);

        return Ok(response);
    }

    [HttpDelete]
    public IActionResult DeleteRoomType(DeleteRoomTypeRequest request)
    {
        var result = sender.Send(new DeleteRoomTypeCommand(request.RoomTypeId)).Result;

        if (result.IsFailure)
        {
            HandleFailure(result);
        }

        var roomType = result.Value.RoomType;
        var response = new RoomTypeResponse(
            roomType.Id.Value,
            roomType.Floor.Name,
            roomType.BedCount,
            roomType.Price.Amount,
            roomType.Price.Currency);

        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetAllRoomType()
    {
        var result = sender.Send(new GetAllRoomTypeQuery()).Result;

        var roomTypes = result.Value.RoomTypes;
        var responses =
            roomTypes.Select(roomType =>
                new RoomTypeResponse(
                    roomType.Id.Value,
                    roomType.Floor.Name,
                    roomType.BedCount,
                    roomType.Price.Amount,
                    roomType.Price.Currency)).ToList();

        return Ok(new RoomTypeList(responses));
    }
}
