using Domain.Common.Primitives;

namespace Domain.RoomType.Enums;

public abstract class Floor : Enumeration<Floor>
{
    public static readonly Floor Fb = new FloorB();
    public static readonly Floor Fg = new FloorG();
    public static readonly Floor F1 = new Floor1();
    public static readonly Floor F2 = new Floor2();

    private Floor(int value, string name) : base(value, name)
    {
    }

    private sealed class FloorB : Floor
    {
        public FloorB() : base(-1, "B")
        {
        }
    }
    private sealed class FloorG : Floor
    {
        public FloorG() : base(0, "G")
        {
        }
    }
    private sealed class Floor1 : Floor
    {
        public Floor1() : base(1, "1")
        {
        }
    }
    private sealed class Floor2 : Floor
    {
        public Floor2() : base(2, "2")
        {
        }
    }
}
