using Domain.Common.Shared;

namespace Domain.Common.Exceptions;

public static partial class DomainException
{
    public static class Room
    {
        public static Error RoomNotFound => new("RoomNotFound", "Room not found.");
    }
}
