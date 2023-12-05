using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.Bookings.BookingManagement;
using Application.Bookings.BookingManagement.CancelBooking;
using Application.RoomTypes;
using Application.Users;
using Domain.Booking;
using Domain.Booking.Enums;
using Domain.Booking.Exceptions;
using Domain.Booking.ValueObjects;
using Domain.Common.Exceptions;
using Domain.Common.Shared;
using Domain.RoomType;
using Domain.RoomType.ValueObjects;
using Domain.User.Enums;
using Domain.User.Exceptions;
using Domain.User.ValueObjects;
using DomainException = Domain.User.Exceptions.DomainException;

namespace Application.Bookings.BookingManagement.CreateBooking;
internal sealed class CancelBookingCommandHandler(
    IBookingRepository bookingRepository,
    IUserRepository userRepository) : ICommandHandler<CancelBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetByIdAsync(BookingId.Create(request.BookingId));
        if (booking is null)
        {
            return (Result<BookingResult>)Result.Failure(BookingException.Booking.InvalidBookingId);
        }

        var user = await userRepository.GetByIdAsync(UserId.Create(request.UserId));
        if (user is null)
        {
            return (Result<BookingResult>)Result.Failure(DomainException.User.UserNotFound);
        }

        booking.BookingStatus = BookingStatus.Cancelled;

        var updatestatus = bookingRepository.UpdateAsync(booking);

        Task.WaitAll(new Task[] { updatestatus },
                     cancellationToken);

        return new BookingResult(booking);
    }
}
