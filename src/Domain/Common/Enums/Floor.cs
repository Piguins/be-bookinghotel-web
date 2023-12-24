using Domain.Common.Primitives;

namespace Domain.Common.Enums;

public class Floor : Enumeration<Floor>
{
    public static readonly Floor FloorB = new(1, nameof(FloorB));
    public static readonly Floor FloorG = new(2, nameof(FloorG));
    public static readonly Floor Floor1 = new(3, nameof(Floor1));
    public static readonly Floor Floor2 = new(4, nameof(Floor2));

    private Floor(int value, string name) : base(value, name)
    {
    }

    // private sealed class FloorB : Floor
    // {
    //     public FloorB() : base(-1, "FloorB")
    //     {
    //     }
    // }
    // private sealed class FloorG : Floor
    // {
    //     public FloorG() : base(0, "FloorG")
    //     {
    //     }
    // }
    // private sealed class Floor1 : Floor
    // {
    //     public Floor1() : base(1, "Floor1")
    //     {
    //     }
    // }
    // private sealed class Floor2 : Floor
    // {
    //     public Floor2() : base(2, "Floor2")
    //     {
    //     }
    // }
}
