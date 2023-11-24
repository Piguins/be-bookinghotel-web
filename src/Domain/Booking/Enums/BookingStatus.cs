using Domain.Common.Primitives;

namespace Domain.Booking.Enums;

// public enum BookingStatus
// {
//     Confirmed,
//     Pending,
//     Paid,
//     Created,
// }
public abstract class BookingStatus : Enumeration<BookingStatus>
{
    public static readonly BookingStatus Confirmed = new ConfirmedBookingStatus();
    public static readonly BookingStatus Pending = new PendingBookingStatus();
    public static readonly BookingStatus Paid = new PaidBookingStatus();
    public static readonly BookingStatus Created = new CreatedBookingStatus();
    public static readonly BookingStatus Cancelled = new CancelledBookingStatus();

    private BookingStatus(int value, string name) : base(value, name)
    {
    }

    private sealed class ConfirmedBookingStatus : BookingStatus
    {
        public ConfirmedBookingStatus() : base(1, "Confirmed")
        {
        }
    }
    private sealed class PendingBookingStatus : BookingStatus
    {
        public PendingBookingStatus() : base(2, "Pending")
        {
        }
    }
    private sealed class PaidBookingStatus : BookingStatus
    {
        public PaidBookingStatus() : base(3, "Paid")
        {
        }
    }
    private sealed class CreatedBookingStatus : BookingStatus
    {
        public CreatedBookingStatus() : base(4, "Created")
        {
        }
    }
    private sealed class CancelledBookingStatus : BookingStatus
    {
        public CancelledBookingStatus() : base(5, "Cancelled")
        {
        }
    }

    // #pragma warning disable CS8618
    //     protected BookingStatus() { }
    // #pragma warning restore CS8618
}
