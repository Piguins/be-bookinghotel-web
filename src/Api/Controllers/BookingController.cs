using Api.Abstractions;
using Application.Bookings;
using Application.Bookings.BookingManagement.BookingManagementCommands.CancelBooking;
using Application.Bookings.BookingManagement.BookingManagementCommands.ConfirmBooking;
using Application.Bookings.BookingManagement.BookingManagementCommands.CreateBooking;
using Application.Bookings.BookingManagement.BookingManagementCommands.UpdateBooking;
using Application.Bookings.BookingManagement.BookingManagementQueries.GetAllBooking;
using Application.Bookings.BookingManagement.BookingManagementQueries.GetAllBookings;
using Contracts.BookingManagement;
using Contracts.BookingManagement.Commands;
using Contracts.BookingManagement.Queries;
using Domain.Booking;
using Domain.RoomType.ValueObjects;
using Domain.User.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Api.Controllers;

[Route("bookings")]
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

    [HttpGet]
    public IActionResult GetAllBookings(GetAllBookingsRequest request)
    {
        var result = _sender.Send(new GetAllBookingQuery()).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var bookings = result.Value.Bookings;
        var responses = new List<BookingResponse>();

        foreach(var booking in bookings)
        {
            var response = new BookingResponse(
            booking.Id.Value,
            booking.UserId.Value,
            booking.RoomTypeId.Value,
            booking.FromDate,
            booking.EndDate,
            booking.BookingStatus.Name,
            booking.RoomCount);
            responses.Add(response);
        }

        return Ok(responses);
    }

    [HttpGet("user")]
    public IActionResult GetBookingsByUserId(GetBookingsByUserIdRequest request)
    {
        var result = _sender.Send(new GetBookingsByUserIdQuery(request.UserId)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var bookings = result.Value.Bookings;
        var responses = new List<BookingResponse>();

        foreach (var booking in bookings)
        {
            var response = new BookingResponse(
            booking.Id.Value,
            booking.UserId.Value,
            booking.RoomTypeId.Value,
            booking.FromDate,
            booking.EndDate,
            booking.BookingStatus.Name,
            booking.RoomCount);
            responses.Add(response);
        }

        return Ok(responses);
    }
}
