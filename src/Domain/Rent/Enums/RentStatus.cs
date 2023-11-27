using Domain.Common.Primitives;

namespace Domain.Rent.Enums;

// public enum RentStatus
// {
//     Renting,
//     Cancelled,
//     Returned,
// }
public abstract class RentStatus : Enumeration<RentStatus>
{
    public static readonly RentStatus Renting = new RentingRentStatus();
    public static readonly RentStatus Cancelled = new CancelledRentStatus();
    public static readonly RentStatus Returned = new ReturnedRentStatus();

    private RentStatus(int value, string name) : base(value, name)
    {
    }

    public sealed class RentingRentStatus : RentStatus
    {
        public RentingRentStatus() : base(1, "Renting")
        {
        }
    }
    public sealed class CancelledRentStatus : RentStatus
    {
        public CancelledRentStatus() : base(2, "Cancelled")
        {
        }
    }
    public sealed class ReturnedRentStatus : RentStatus
    {
        public ReturnedRentStatus() : base(3, "Returned")
        {
        }
    }

    // #pragma warning disable CS8618
    //     protected RentStatus() { }
    // #pragma warning restore CS8618
}
