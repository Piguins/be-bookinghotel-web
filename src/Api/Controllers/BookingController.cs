using Api.Commons;
using Application.Bookings.Commands.CreateBooking;
using Application.Bookings.Queries.GetAllBookings;
using Application.Bookings.Queries.GetBookingsByUserId;
using AutoMapper;
using Contracts.Booking;
using Contracts.Booking.Requests;
using Infrastructure.Services.Authorization;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

public class BookingController(ISender sender, IMapper mapper) : ApiController
{
    [HttpPost]
    public IActionResult CreateBooking(CreateBookingRequest request)
    {
        if (User.GetUserId() is not { } userId)
        {
            return BadRequest();
        }
        var result = sender.Send(new CreateBookingCommand(
            userId,
            request.OrderId,
            request.FromDate,
            request.ToDate,
            request.Floor,
            request.BedCount)).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(mapper.Map<BookingResponse>(result.Value));
    }

    // [HttpPut("{bookingId}/confirm")]
    // [Authorize(Policy = nameof(PermissionRequirement.Host))]
    // public IActionResult ConfirmBooking(Guid bookingId)
    // {
    //     var result = sender.Send(new ConfirmBookingCommand(bookingId)).Result;
    //
    //     return result.IsFailure
    //         ? HandleFailure(result)
    //         : Ok(mapper.Map<BookingResponse>(result.Value));
    // }
    //
    // [HttpPut("{bookingId}/cancel")]
    // public IActionResult CancelBooking(Guid bookingId)
    // {
    //     var result = sender.Send(new CancelBookingCommand(bookingId)).Result;
    //
    //     return result.IsFailure
    //         ? HandleFailure(result)
    //         : Ok(mapper.Map<BookingResponse>(result.Value));
    // }
    //
    // [HttpPut]
    // public IActionResult UpdateBooking(UpdateBookingRequest request)
    // {
    //     var result = sender.Send(new UpdateBookingCommand(
    //         request.BookingId,
    //         request.FromDate,
    //         request.ToDate,
    //         request.Floor,
    //         request.BedCount)).Result;
    //
    //     return result.IsFailure
    //         ? HandleFailure(result)
    //         : Ok(mapper.Map<BookingResponse>(result.Value));
    // }

    [HttpGet]
    public IActionResult GetBookingsByUserId()
    {
        if (User.GetUserId() is not { } userId)
        {
            return BadRequest();
        }
        var result = sender.Send(new GetBookingsByUserIdQuery(userId)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var responses = result.Value.ConvertAll(mapper.Map<BookingResponse>);
        return Ok(responses);
    }

    [HttpGet("get-all")]
    // [AllowAnonymous]
    [Authorize(Policy = nameof(PermissionRequirement.Host))]
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
