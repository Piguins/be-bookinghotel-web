namespace Application.Bookings.Queries.GetAllBookings;

internal sealed class GetAllBookingQueryHandler(
    IMapper mapper,
    IBookingRepository bookingRepository) : IQueryHandler<GetAllBookingQuery, ListBookingResult>
{
    public async Task<Result<ListBookingResult>> Handle(GetAllBookingQuery request, CancellationToken cancellationToken)
    {
        var bookings = await bookingRepository.GetAllAsync();
        var results = bookings.Select(mapper.Map<BookingResult>).ToList();
        return new ListBookingResult(results);
    }
}
