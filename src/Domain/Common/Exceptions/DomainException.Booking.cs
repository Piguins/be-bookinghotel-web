using Domain.Common.Shared;

namespace Domain.Common.Exceptions;

public static partial class DomainException
{
    public static class Booking
    {
        public static Error InvalidBookingId => new("Invalid Booking Id", "this booking id doesn't exist");
        public static Error BookingNotFound => new("BookingNotFound", "Booking not found.");
    }
}
