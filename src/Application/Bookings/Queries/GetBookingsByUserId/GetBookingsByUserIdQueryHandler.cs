using Application.Users;
using Domain.User.ValueObjects;

namespace Application.Bookings.Queries.GetBookingsByUserId;

internal sealed class GetBookingsByUserId(
    IBookingRepository bookingRepository,
    IMapper mapper,
    IUserRepository userRepository) : IQueryHandler<GetBookingsByUserIdQuery, List<BookingResult>>
{
    public async Task<Result<List<BookingResult>>> Handle(GetBookingsByUserIdQuery request, CancellationToken cancellationToken)
    {
        if (Guid.TryParse(request.UserId, out var guid) is false)
        {
            return Result.Failure<List<BookingResult>>(DomainException.User.InValidId);
        }
        if (await userRepository.GetByIdAsync(UserId.Create(guid)) is null)
        {
            return Result.Failure<List<BookingResult>>(DomainException.User.UserNotFound);
        }

        var bookings = await bookingRepository.GetByUserIdAsync(guid);
        var results = bookings.Select(mapper.Map<BookingResult>).ToList();
        return results;
    }
}
