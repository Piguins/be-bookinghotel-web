using Domain.Common.Shared;

namespace Domain.Common.Exceptions;

public static partial class DomainException
{
    public static class Room
    {
        public static Error RoomNotFound => new("RoomNotFound", "Room not found.");
        public static Error InvalidFloor => new("Invalid Floor", "this floor number doesn't exist");
    }
}
