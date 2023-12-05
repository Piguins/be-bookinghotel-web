using Domain.Common.Exceptions;
using Domain.Common.Shared;

namespace Domain.Booking.Exceptions;

public static partial class BookingException
{
    public static class Booking
    {
        // Common
        public static Error InvalidBookingId => new("InvalidBookingId", "This ID doesn't not exist");

        // Register
        

        // Login
        public static Error InvalidCredentials => new("InvalidCredentials", "Invalid credentials.");

        // Repository
        public static Error UserNotFound => new("UserNotFound", "User not found.");
    }
}
