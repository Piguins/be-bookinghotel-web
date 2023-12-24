using Domain.Common.Enums;
using Domain.Rooms;
using Domain.Rooms.Entities;

namespace Application.Rooms;

public class RoomMapper : Profile
{
    public RoomMapper()
    {
        CreateMap<Floor, string>()
            .ConvertUsing(floor => floor.Name);
        CreateMap<RoomImage, string>()
            .ConvertUsing(floor => floor.Url);
        CreateMap<Room, RoomResult>()
            .ForMember(dest => dest.PriceCurrency, opt => opt.MapFrom(src => src.Price.Currency))
            .ForMember(dest => dest.PriceAmount, opt => opt.MapFrom(src => src.Price.Amount));
    }
}

