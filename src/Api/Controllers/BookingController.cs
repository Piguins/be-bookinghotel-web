using Api.Abstractions;
using Application.Bookings.Commands.CancelBooking;
using Application.Bookings.Commands.ConfirmBooking;
using Application.Bookings.Commands.CreateBooking;
using Application.Bookings.Commands.UpdateBooking;
using Application.Bookings.Queries.GetAllBookings;
using Application.Bookings.Queries.GetBookingsByUserId;
using AutoMapper;
using Contracts.Booking;
using Contracts.Booking.Commands;
using Contracts.Booking.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class BookingController(ISender sender, IMapperBase mapper) : ApiController
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

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

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

    [HttpGet]
    public IActionResult GetAllBookings(GetAllBookingsRequest request)
    {
        var result = sender.Send(new GetAllBookingQuery()).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var responses = result.Value.Bookings.ConvertAll(mapper.Map<BookingResponse>);
        return Ok(new ListBookingResponse(responses));
    }

    [HttpGet("user")]
    public IActionResult GetBookingsByUserId(GetBookingsByUserIdRequest request)
    {
        var result = sender.Send(new GetBookingsByUserIdQuery(request.UserId)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var responses = result.Value.Bookings.ConvertAll(mapper.Map<BookingResponse>);
        return Ok(new ListBookingResponse(responses));
    }
}
