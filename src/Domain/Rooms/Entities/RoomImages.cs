using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Domain.Rooms.ValueObjects;

namespace Domain.Rooms.Entities;

public sealed class RoomImage : Entity<RoomImageId>
{
    private RoomImage(RoomImageId id, RoomId roomId, string url) : base(id)
    {
        RoomId = roomId;
        Url = url;
    }

    public RoomId RoomId { get; private set; }
    public string Url { get; private set; }

    public static RoomImage Create(
        RoomId roomId,
        string url,
        Guid? id = null)
            => new(RoomImageId.Create(id ?? BaseId.NewId),
                   roomId,
                   url);

#pragma warning disable CS8618
    private RoomImage() { }
#pragma warning restore CS8618
}
