using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.Bookings.BookingManagement.BookingManagementQueries.GetAllBooking;
using Domain.Booking;
using Domain.Common.Shared;

namespace Application.Bookings.BookingManagement.BookingManagementQueries.GetBookingsByUserId;
internal sealed class GetBookingsByUserId(IBookingRepository bookingRepository) : IQueryHandler<GetBookingsByUserIdQuery, BookingQueryResult>
{
    public async Task<Result<BookingQueryResult>> Handle(GetBookingsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var bookings = bookingRepository.GetByUserIdAsync(request.UserId);

        Task.WaitAll(new Task[] { bookings },
            cancellationToken);

        return new BookingQueryResult(bookings.Result.ToList());
    }
}
