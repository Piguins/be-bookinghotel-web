namespace Application.Rooms.Queries.GetRoomByRoomTypeId;

public record GetRoomByRoomTypeIdQuery(string RoomTypeId) : IQuery<RoomQueryResult>;
