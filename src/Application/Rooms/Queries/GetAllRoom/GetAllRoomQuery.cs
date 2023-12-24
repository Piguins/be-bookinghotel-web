namespace Application.Rooms.Queries.GetAllRoom;

public record GetAllRoomQuery(
    decimal MinPrice = 0,
    decimal MaxPrice = 0) : IQuery<ICollection<RoomResult>>;
