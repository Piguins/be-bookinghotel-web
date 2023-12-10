using Api.Commons;
using Application.RoomTypes.Commands.CreateRoomType;
using Application.RoomTypes.Commands.DeleteRoomType;
using Application.RoomTypes.Queries.GetAllRoomType;
using Contracts.RoomType;
using Contracts.RoomType.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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



        return result.IsFailure
            ? HandleFailure(result)
            : Ok(new RoomTypeResponse(
                    result.Value.RoomType.Id.Value,
                    result.Value.RoomType.Floor.Name,
                    result.Value.RoomType.BedCount,
                    result.Value.RoomType.Price.Amount,
                    result.Value.RoomType.Price.Currency));
    }

    [HttpDelete]
    public IActionResult DeleteRoomType(DeleteRoomTypeRequest request)
    {
        var result = sender.Send(new DeleteRoomTypeCommand(request.RoomTypeId)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(new RoomTypeResponse(
                    result.Value.RoomType.Id.Value,
                    result.Value.RoomType.Floor.Name,
                    result.Value.RoomType.BedCount,
                    result.Value.RoomType.Price.Amount,
                    result.Value.RoomType.Price.Currency));
    }

    [HttpGet("get-all")]
    [AllowAnonymous]
    public IActionResult GetAllRoomType()
    {
        var result = sender.Send(new GetAllRoomTypeQuery()).Result;

        var responses =
            result.Value.RoomTypes.Select(roomType =>
                new RoomTypeResponse(
                    roomType.Id.Value,
                    roomType.Floor.Name,
                    roomType.BedCount,
                    roomType.Price.Amount,
                    roomType.Price.Currency)).ToList();

        return Ok(responses);
    }
}
