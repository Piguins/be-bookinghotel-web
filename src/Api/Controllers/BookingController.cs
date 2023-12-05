using Api.Abstractions;
using Application.Bookings;
using Application.Bookings.BookingManagement.CancelBooking;
using Application.Bookings.BookingManagement.CreateBooking;
using Application.Bookings.BookingManagement.UpdateBooking;
using Contracts.BookingManagement;
using Domain.Booking;
using Domain.RoomType.ValueObjects;
using Domain.User.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Api.Controllers;

[Route("booking")]
public class BookingController : ApiController
{
    public BookingController(ISender sender) : base(sender)
    {
    }

    [HttpPost("create")]
    public IActionResult CreateBooking(CreateBookingRequest request)
    {
        var result = _sender.Send(new CreateBookingCommand(
            request.UserId,
            request.RoomTypeId,
            request.FromDate,
            request.ToDate,
            request.RoomCount)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var booking = result.Value.Booking;

        var response = new BookingResponse(
            booking.Id.Value,
            booking.UserId.Value,
            booking.RoomTypeId.Value,
            booking.FromDate,
            booking.EndDate,
            booking.BookingStatus.Name,
            booking.RoomCount);

        return Ok(response);
    }

    [HttpPost("confirm")]
    public IActionResult ConfirmBooking(ConfirmBookingRequest request)
    {
        var result = _sender.Send(new ConfirmBookingCommand(
            request.BookingId,
            request.UserId)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var booking = result.Value.Booking;

        var response = new BookingResponse(
            booking.Id.Value,
            booking.UserId.Value,
            booking.RoomTypeId.Value,
            booking.FromDate,
            booking.EndDate,
            booking.BookingStatus.Name,
            booking.RoomCount);

        return Ok(response);
    }
    [HttpPost("cancel")]
    public IActionResult CancelBooking(CancelBookingRequest request)
    {
        var result = _sender.Send(new CancelBookingCommand(
            request.BookingId,
            request.UserId)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var booking = result.Value.Booking;

        var response = new BookingResponse(
            booking.Id.Value,
            booking.UserId.Value,
            booking.RoomTypeId.Value,
            booking.FromDate,
            booking.EndDate,
            booking.BookingStatus.Name,
            booking.RoomCount);

        return Ok(response);
    }
    [HttpPut("update")]
    public IActionResult UpdateBooking(UpdateBookingRequest request)
    {
        var result = _sender.Send(new UpdateBookingCommand(
            request.UserId,
            request.BookingId,
            request.RoomTypeId,
            request.FromDate,
            request.ToDate,
            request.RoomCount)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var booking = result.Value.Booking;

        var response = new BookingResponse(
            booking.Id.Value,
            booking.UserId.Value,
            booking.RoomTypeId.Value,
            booking.FromDate,
            booking.EndDate,
            booking.BookingStatus.Name,
            booking.RoomCount);

        return Ok(response);
    }
}
