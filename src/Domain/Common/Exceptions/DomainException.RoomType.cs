using Domain.Common.Shared;

namespace Domain.Common.Exceptions;
public static partial class DomainException
{
    public static class RoomType
    {
        public static Error RoomTypeNotFound => new("RoomTypeNotFound", "RoomType not found.");
        public static Error InvalidFloor => new("Invalid Floor", "this floor number doesn't exist");
    }
}
