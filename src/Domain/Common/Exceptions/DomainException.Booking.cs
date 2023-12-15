using Domain.Common.Shared;

namespace Domain.Common.Exceptions;

public static partial class DomainException
{
    public static class Booking
    {
        public static Error InvalidBookingId => new("Invalid Booking Id", "this booking id doesn't exist");
        public static Error BookingNotFound => new("BookingNotFound", "Booking not found.");
        public static Error BookingIsConfirmed => new("BookingIsConfirmed", "Cannot Update Booking Due To Confirmed Status.");
        public static Error BookingIsCancelled => new("BookingIsCancelled", "Cannot Update Booking Due To Cancelled Status.");
    }
}
