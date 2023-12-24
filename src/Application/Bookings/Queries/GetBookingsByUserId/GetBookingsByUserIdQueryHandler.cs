using Application.Users;
using Domain.Users.ValueObjects;

namespace Application.Bookings.Queries.GetBookingsByUserId;

internal sealed class GetBookingsByUserId(
    IBookingRepository bookingRepository,
    IMapper mapper,
    IUserRepository userRepository) : IQueryHandler<GetBookingsByUserIdQuery, List<BookingResult>>
{
    public async Task<Result<List<BookingResult>>> Handle(GetBookingsByUserIdQuery request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByIdAsync(UserId.Create(request.UserId)) is null)
        {
            return Result.Failure<List<BookingResult>>(DomainException.User.UserNotFound);
        }

        var bookings = await bookingRepository.GetByUserIdAsync(request.UserId);
        var results = bookings.Select(mapper.Map<BookingResult>).ToList();
        return results;
    }
}
