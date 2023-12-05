using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.Bookings.BookingManagement;
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
internal sealed class ConfirmBookingCommandHandler(
    IBookingRepository bookingRepository,
    IUserRepository userRepository) : ICommandHandler<ConfirmBookingCommand, BookingResult>
{
    public async Task<Result<BookingResult>> Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
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
        if(user.Roles != Role.Host)
        {
            return (Result<BookingResult>)Result.Failure(DomainException.User.InvalidCredentials);
        }

        booking.BookingStatus = BookingStatus.Confirmed;

        var updatestatus = bookingRepository.UpdateAsync(booking);

        Task.WaitAll(new Task[] { updatestatus },
                     cancellationToken);

        return new BookingResult(booking);
    }
}
