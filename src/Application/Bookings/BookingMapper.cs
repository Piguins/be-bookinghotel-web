using Application.Users;
using Domain.Bookings;

namespace Application.Bookings;

public class BookingMapper : Profile
{
    public BookingMapper()
    {
        CreateMap<Booking, BookingResult>()
            .ConstructUsing((x, m) => new BookingResult(
                x.Id.Value,
                x.OrderId.Value,
                x.FromDate,
                x.ToDate,
                x.Floor.ToString()!,
                x.BedCount,
                m.Mapper.Map<UserResult>(x.User)));
    }
}

