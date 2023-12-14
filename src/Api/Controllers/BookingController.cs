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
using Infrastructure.Services.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

public class BookingController(ISender sender, IMapper mapper) : ApiController
{
    [HttpPost]
    [Authorize(Policy = nameof(PermissionRequirement.Guest))]
    public IActionResult CreateBooking(CreateBookingRequest request)
    {
        var result = sender.Send(new CreateBookingCommand(
            request.UserId,
            request.FromDate,
            request.ToDate,
            request.Floor,
            request.BedCount)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(mapper.Map<BookingResponse>(result.Value));
    }

    [HttpPut("{bookingId}/confirm")]
    public IActionResult ConfirmBooking(Guid bookingId)
    {
        var result = sender.Send(new ConfirmBookingCommand(bookingId)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(mapper.Map<BookingResponse>(result.Value));
    }

    [HttpPut("{bookingId}/cancel")]
    [Authorize(Policy = nameof(PermissionRequirement.Guest))]
    public IActionResult CancelBooking(Guid bookingId)
    {
        var result = sender.Send(new CancelBookingCommand(bookingId)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(mapper.Map<BookingResponse>(result.Value));
    }

    [HttpPut]
    [Authorize(Policy = nameof(PermissionRequirement.Guest))]
    public IActionResult UpdateBooking(UpdateBookingRequest request)
    {
        var result = sender.Send(new UpdateBookingCommand(
            request.BookingId,
            request.FromDate,
            request.ToDate,
            request.Floor,
            request.BedCount)).Result;

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
