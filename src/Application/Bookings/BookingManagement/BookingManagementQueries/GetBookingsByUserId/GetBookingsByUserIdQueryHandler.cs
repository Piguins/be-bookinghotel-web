using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.Bookings.BookingManagement.BookingManagementQueries.GetAllBooking;
using Application.Users;
using Domain.Booking;
using Domain.Common.Shared;
using Domain.User.Exceptions;
using Domain.User.ValueObjects;

namespace Application.Bookings.BookingManagement.BookingManagementQueries.GetBookingsByUserId;
internal sealed class GetBookingsByUserId(IBookingRepository bookingRepository, IUserRepository userRepository) : IQueryHandler<GetBookingsByUserIdQuery, BookingQueryResult>
{
    public async Task<Result<BookingQueryResult>> Handle(GetBookingsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(UserId.Create(request.UserId));
        if (user is null)
        {
            return (Result<BookingQueryResult>)Result.Failure(DomainException.User.UserNotFound);
        }

        var bookings = bookingRepository.GetByUserIdAsync(request.UserId);

        Task.WaitAll(new Task[] { bookings },
            cancellationToken);

        return new BookingQueryResult(bookings.Result.ToList());
    }
}
