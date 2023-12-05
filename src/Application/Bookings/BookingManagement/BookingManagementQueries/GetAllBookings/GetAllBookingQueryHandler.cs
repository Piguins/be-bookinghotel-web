using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.Booking;
using Domain.Common.Shared;

namespace Application.Bookings.BookingManagement.BookingManagementQueries.GetAllBookings;
internal sealed class GetAllBookingQueryHandler(IBookingRepository bookingRepository) : IQueryHandler<GetAllBookingQuery, BookingQueryResult>
{
    public async Task<Result<BookingQueryResult>> Handle(GetAllBookingQuery request, CancellationToken cancellationToken)
    {
        var bookings = bookingRepository.GetAllAsync();

        Task.WaitAll(new Task[] { bookings },
            cancellationToken);

        return new BookingQueryResult(bookings.Result.ToList());
    }
}
