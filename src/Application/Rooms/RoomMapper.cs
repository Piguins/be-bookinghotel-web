using Domain.Common.Enums;
using Domain.Room;

namespace Application.Rooms;

public class RoomMapper : Profile
{
    public RoomMapper()
    {
        CreateMap<Floor, string>()
            .ConvertUsing(floor => floor.Name);
        CreateMap<Room, RoomResult>()
            .ForMember(dest => dest.PriceCurrency, opt => opt.MapFrom(src => src.Price.Currency))
            .ForMember(dest => dest.PriceAmount, opt => opt.MapFrom(src => src.Price.Amount));
    }
}

