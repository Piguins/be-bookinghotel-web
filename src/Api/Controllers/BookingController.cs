using Api.Abstractions;
using Application.Bookings;
using Contracts.BookingManagement;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Api.Controllers;

[Route("booking")]
public class BookingController : ApiController
{

    private readonly IBookingService _bookingService;
    public BookingController(ISender sender, IBookingService bookingService) : base(sender)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public IActionResult CreateBooking(CreateBookingRequest request)
    {
        var result = _bookingService.CreateBooking(
            request.UserId,
            request.RoomTypeId,
            request.FromDate,
            request.ToDate,
            request.RoomCount);

        var response = new CreateBookingResponse(result.Result.Booking.Id.Value);

        return Ok(response);
    }
}
