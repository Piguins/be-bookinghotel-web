using Domain.Booking;

namespace Application.Bookings;

public class BookingMapper : Profile
{
    public BookingMapper()
    {
        CreateMap<Booking, BookingResult>()
            .ConstructUsing(x => new BookingResult(
                x.Id.Value,
                x.UserId.Value,
                x.RoomTypeId.Value,
                x.FromDate,
                x.ToDate,
                x.RoomCount,
                x.BookingStatus.ToString() ?? string.Empty));
    }
}

