using Domain.Booking;

namespace Application.Bookings;

public class BookingMapper : Profile
{
    public BookingMapper()
    {
        CreateMap<Booking, BookingResult>()
            .ConstructUsing(x => new BookingResult(
                x.Id.Value,
                x.GuestId.Value,
                x.FromDate,
                x.ToDate,
                x.Floor.ToString()!,
                x.BedCount,
                x.BookingStatus.ToString() ?? string.Empty));
    }
}

