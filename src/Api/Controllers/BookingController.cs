using Api.Commons;
using Application.Bookings.Commands.CancelBooking;
using Application.Bookings.Commands.ConfirmBooking;
using Application.Bookings.Commands.CreateBooking;
using Application.Bookings.Commands.UpdateBooking;
using Application.Bookings.Queries.GetAllBookings;
using Application.Bookings.Queries.GetBookingsByUserId;
using AutoMapper;
using Contracts.Booking;
using Contracts.Booking.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

public class BookingController(ISender sender, IMapper mapper) : ApiController
{
    [HttpPost]
    public IActionResult CreateBooking(CreateBookingRequest request)
    {
        var result = sender.Send(new CreateBookingCommand(
            request.UserId,
            request.RoomTypeId,
            request.FromDate,
            request.ToDate,
            request.RoomCount)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(mapper.Map<BookingResponse>(result.Value));
    }

    [HttpPut("confirm")]
    public IActionResult ConfirmBooking(ConfirmBookingRequest request)
    {
        var result = sender.Send(new ConfirmBookingCommand(
            request.BookingId,
            request.UserId)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(mapper.Map<BookingResponse>(result.Value));
    }
    [HttpPut("cancel")]
    public IActionResult CancelBooking(CancelBookingRequest request)
    {
        var result = sender.Send(new CancelBookingCommand(
            request.BookingId,
            request.UserId)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(mapper.Map<BookingResponse>(result.Value));
    }
    [HttpPut("update")]
    public IActionResult UpdateBooking(UpdateBookingRequest request)
    {
        var result = sender.Send(new UpdateBookingCommand(
            request.UserId,
            request.BookingId,
            request.RoomTypeId,
            request.FromDate,
            request.ToDate,
            request.RoomCount)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(mapper.Map<BookingResponse>(result.Value));
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetBookingsByUserId(string userId)
    {
        var result = sender.Send(new GetBookingsByUserIdQuery(userId)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var responses = result.Value.ConvertAll(mapper.Map<BookingResponse>);
        return Ok(responses);
    }

    [HttpGet("get-all")]
    [AllowAnonymous]
    public IActionResult GetAllBookings()
    {
        var result = sender.Send(new GetAllBookingQuery()).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var responses = result.Value.ConvertAll(mapper.Map<BookingResponse>);
        return Ok(responses);
    }

}
