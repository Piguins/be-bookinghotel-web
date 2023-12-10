using Domain.RoomType;

namespace Application.RoomTypes.Queries;

public record RoomTypeQueryResult(
    List<RoomType> RoomTypes);
