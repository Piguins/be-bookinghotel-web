using Application.Users;
using Domain.User.ValueObjects;

namespace Application.Bookings.Queries.GetBookingsByUserId;

internal sealed class GetBookingsByUserId(
    IBookingRepository bookingRepository,
    IMapper mapper,
    IUserRepository userRepository) : IQueryHandler<GetBookingsByUserIdQuery, ListBookingResult>
{
    public async Task<Result<ListBookingResult>> Handle(GetBookingsByUserIdQuery request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByIdAsync(UserId.Create(request.UserId)) is null)
        {
            return Result.Failure<ListBookingResult>(DomainException.User.UserNotFound);
        }

        var bookings = await bookingRepository.GetByUserIdAsync(request.UserId);
        var results = bookings.Select(mapper.Map<BookingResult>).ToList();
        return new ListBookingResult(results);
    }
}
