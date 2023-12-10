namespace Application.Bookings.Queries.GetAllBookings;

internal sealed class GetAllBookingQueryHandler(
    IMapper mapper,
    IBookingRepository bookingRepository) : IQueryHandler<GetAllBookingQuery, List<BookingResult>>
{
    public async Task<Result<List<BookingResult>>> Handle(GetAllBookingQuery request, CancellationToken cancellationToken)
    {
        var bookings = await bookingRepository.GetAllAsync();
        var results = bookings.Select(mapper.Map<BookingResult>).ToList();
        return results;
    }
}
