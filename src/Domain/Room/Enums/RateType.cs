using Domain.Common.Primitives;

namespace Domain.Room.Enums;

public abstract class RateType : Enumeration<RateType>
{
    public static readonly RateType Great = new GreatRateType();
    public static readonly RateType Good = new GoodRateType();
    public static readonly RateType Average = new AverageRateType();
    public static readonly RateType Poor = new PoorRateType();
    public static readonly RateType Terrible = new TerribleRateType();

    private RateType(int value, string name) : base(value, name)
    {
    }

    private sealed class GreatRateType : RateType
    {
        public GreatRateType() : base(5, "Great")
        {
        }
    }
    private sealed class GoodRateType : RateType
    {
        public GoodRateType() : base(4, "Good")
        {
        }
    }
    private sealed class AverageRateType : RateType
    {
        public AverageRateType() : base(3, "Average")
        {
        }
    }
    private sealed class PoorRateType : RateType
    {
        public PoorRateType() : base(2, "Poor")
        {
        }
    }
    private sealed class TerribleRateType : RateType
    {
        public TerribleRateType() : base(1, "Terrible")
        {
        }
    }
}
