using AutoMapper;
using Application.Bookings;
using Application.Users;
using Contracts.Booking;
using Contracts.User;

namespace Api.Commons;

public class ApiMapper : Profile
{
    public ApiMapper()
    {
        CreateMap<BookingResult, BookingResponse>();
        CreateMap<RoleResult, RoleResponse>();
        CreateMap<UserResult, UserResponse>()
            .ConstructUsing((src, ctx) => new UserResponse(
                src.Id,
                src.FirstName,
                src.LastName,
                src.Email,
                ctx.Mapper.Map<ICollection<RoleResponse>>(src.Roles)
            ));
    }
}
