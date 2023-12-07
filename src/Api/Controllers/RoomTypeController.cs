using Api.Abstractions;
using Application.RoomTypes.Commands;
using Application.RoomTypes.Commands.CreateRoomType;
using Application.RoomTypes.Commands.DeleteRoomType;
using Application.RoomTypes.Queries.GetAllRoomType;
using Contracts.BookingManagement;
using Contracts.RoomType;
using Contracts.RoomType.Commands;
using Domain.Common.Shared;
using Domain.Common.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("Roomtypes")]
public class RoomTypeController : ApiController
{
    public RoomTypeController(ISender sender) : base(sender)
    {
    }

    [HttpPost("create")]
    public IActionResult CreateRoomType(CreateRoomTypeRequest request)
    {
        var result = _sender.Send(new CreateRoomTypeCommand(
            request.Floor,
            request.BedCount,
            request.Amount,
            request.Currency)).Result;

        if(result.IsFailure)
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

    [HttpDelete("delete")]
    public IActionResult DeleteRoomType(DeleteRoomTypeRequest request)
    {
        var result = _sender.Send(new DeleteRoomTypeCommand(request.RoomTypeId)).Result;

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
    public IActionResult GetAllRoomType(GetAllRoomTypeQuery request)
    {
        var result = _sender.Send(new GetAllRoomTypeQuery()).Result;

        var roomTypes = result.Value.RoomTypes;
        var responses = new List<RoomTypeResponse>();

        foreach (var roomType in roomTypes)
        {
            var response = new RoomTypeResponse(
                roomType.Id.Value,
                roomType.Floor.Name,
                roomType.BedCount,
                roomType.Price.Amount,
                roomType.Price.Currency);
            responses.Add(response);
        }

        return Ok(new RoomTypeList(responses));
    }
}
