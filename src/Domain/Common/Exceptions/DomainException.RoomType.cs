using Domain.Common.Shared;

namespace Domain.Common.Exceptions;
public static partial class DomainException
{
    public static class RoomType
    {
        public static Error RoomTypeNotFound => new("RoomTypeNotFound", "RoomType not found.");
        public static Error RoomTypeIdNotValid => new("RoomTypeIdNotValid", "RoomTypeId is not valid.");
    }
}
