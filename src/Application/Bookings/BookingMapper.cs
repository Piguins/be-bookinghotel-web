using Domain.Booking;

namespace Application.Bookings;

public class BookingMapper : Profile
{
    public BookingMapper()
    {
        CreateMap<Booking, BookingResult>()
            .ForMember(
                r => r.Id,
                o => o.MapFrom(s => s.Id.Value))
            .ForMember(
                r => r.UserId,
                o => o.MapFrom(s => s.UserId.Value))
            .ForMember(
                r => r.RoomTypeId,
                o => o.MapFrom(s => s.RoomTypeId.Value));
    }
}
