using Domain.Common.Exceptions;
using Domain.Common.Shared;

namespace Domain.Booking.Exceptions;

public static partial class DomainException
{
    public static class Booking
    {
        // Common
        public static Error InvalidBookingId => new("InvalidBookingId", "This ID doesn't not valid");

        // Repository
        public static Error BookingNotFound => new("BookingNotFound", "Booking not found.");
    }
}
