namespace Application.Rooms.Queries.GetAllRoom;

public record GetAllRoomQuery() : IQuery<ICollection<RoomResult>>;
