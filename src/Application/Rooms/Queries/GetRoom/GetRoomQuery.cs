namespace Application.Rooms.Queries.GetRoom;

public record GetRoomQuery(Guid RoomId) : IQuery<RoomResult>;
